using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortalRowerowy.API.Helpers;
using PortalRowerowy.API.Models;

namespace PortalRowerowy.API.Data
{
    public class UserRepository : GenericRepository, IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) : base(context)
        {
            _context = context;

        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.UserPhotos)
            .Include(a => a.Adventures).ThenInclude(p => p.AdventurePhotos)
            .Include(s => s.SellBicycles).ThenInclude(p => p.SellBicyclePhotos)
            .FirstOrDefaultAsync(u => u.Id == id); //jak przypisać Adventures, UserPhotos, SellBicycles??
            return user;
        }



        public async Task<PagesList<User>> GetUsers(UserParams userParams)
        {
            var users = _context.Users.Include(p => p.UserPhotos)
            .Include(a => a.Adventures)
            .Include(s => s.SellBicycles)
            .OrderByDescending(u => u.LastActive)
            .AsQueryable();

            users = users.Where(u => u.Id != userParams.UserId);
            //users = users.Where(u => u.Gender == userParams.Gender); //wybieranie płci => UsersController
            if (userParams.Gender != "Wszystkie")
                users = users.Where(u => u.Gender == userParams.Gender);

            if (userParams.UserLikes)
            {
                var userLikes = await GetUserLikes(userParams.UserId, userParams.UserLikes);
                users = users.Where(u => userLikes.Contains(u.Id));
            }

            if (userParams.UserIsLiked)
            {
                var UserIsLiked = await GetUserLikes(userParams.UserId, userParams.UserLikes);
                users = users.Where(u => UserIsLiked.Contains(u.Id));
            }

            if (userParams.AdventureIsLiked)
            {
                var AdventureIsLiked = await GetUserLikesAdventure(userParams.UserId, userParams.UserLikesAdventure);
                users = users.Where(u => AdventureIsLiked.Contains(u.Id));
            }

            if (userParams.UserLikesAdventure)
            {
                var userLikesAdventure = await GetUserLikesAdventure(userParams.UserId, userParams.UserLikesAdventure);
                users = users.Where(u => userLikesAdventure.Contains(u.Id));
            }

            if (userParams.MinAge != 0 || userParams.MaxAge != 100)
            {
                var minDate = DateTime.Today.AddYears(-userParams.MaxAge - 1);
                var maxDate = DateTime.Today.AddYears(-userParams.MinAge);
                users = users.Where(u => u.DateOfBirth >= minDate && u.DateOfBirth <= maxDate);
            }

            if (userParams.TypeBicycle != "Wszystkie")
                users = users.Where(u => u.TypeBicycle == userParams.TypeBicycle);

            if (!string.IsNullOrEmpty(userParams.OrderBy))
            {
                switch (userParams.OrderBy)
                {
                    case "created":
                        users = users.OrderByDescending(u => u.Created);
                        break;
                    default:
                        users = users.OrderByDescending(u => u.LastActive);
                        break;
                }
            }




            return await PagesList<User>.CreateListAsync(users, userParams.PageNumber, userParams.PageSize);
        }
        public async Task<UserPhoto> GetUserPhoto(int id)
        {
            var userPhoto = await _context.UserPhotos.FirstOrDefaultAsync(p => p.Id == id);
            return userPhoto;
        }

        public async Task<UserPhoto> GetMainPhotoForUser(int userId)
        {
            return await _context.UserPhotos.Where(u => u.UserId == userId).FirstOrDefaultAsync(p => p.IsMain);
        }

        public async Task<Like> GetLike(int userId, int recipientId)
        {
            return await _context.Likes.FirstOrDefaultAsync(u => u.UserLikesId == userId && u.UserIsLikedId == recipientId);
        }

        private async Task<IEnumerable<int>> GetUserLikes(int id, bool userLikes)
        {
            var user = await _context.Users
            .Include(x => x.UserLikes)
            .Include(x => x.UserIsLiked)
            .FirstOrDefaultAsync(u => u.Id == id);

            if (userLikes)
            {
                return user
                .UserLikes.Where(u => u.UserIsLikedId == id)
                .Select(i => i.UserLikesId);
            }
            else
            {
                return user.UserIsLiked.Where(u => u.UserLikesId == id)
                .Select(i => i.UserIsLikedId);
            }
        }

        private async Task<IEnumerable<int>> GetUserLikesAdventure(int id, bool userLikesAdventure)
        {
            var adventure = await _context.Adventures
            .Include(x => x.UserLikesAdventure)
            .FirstOrDefaultAsync(u => u.Id == id);

            var user = await _context.Users
            .Include(x => x.AdventureIsLiked)
            .FirstOrDefaultAsync(u => u.Id == id);

            if (userLikesAdventure)
            {
                return user.AdventureIsLiked.Where(u => u.UserLikesAdventureId == id)
                .Select(i => i.AdventureIsLikedId);
   
            }
            else
            {
             return adventure
                .UserLikesAdventure.Where(u => u.AdventureIsLikedId == id)
                .Select(i => i.UserLikesAdventureId);

            }
        }

        public async Task<Message> GetMessage(int id)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<PagesList<Message>> GetMessagesForUser(MessageParams messageParams)
        {
            var messages = _context.Messages.Include(u => u.Sender).ThenInclude(p => p.UserPhotos)
            .Include(u => u.Recipient).ThenInclude(p => p.UserPhotos).AsQueryable();

            switch (messageParams.MessageContainer)
            {
                case "Inbox":
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId && u.RecipientDeleted == false);
                    break;
                case "Outbox":
                    messages = messages.Where(u => u.SenderId == messageParams.UserId && u.SenderDeleted == false);
                    break;
                default:
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId && u.IsRead == false && u.RecipientDeleted == false);
                    break;
            }

            messages = messages.OrderByDescending(d => d.DateSent);

            return await PagesList<Message>.CreateListAsync(messages, messageParams.PageNumber, messageParams.PageSize);
        }

        public async Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId)
        {
            var messages = await _context.Messages
            .Include(u => u.Sender).ThenInclude(p => p.UserPhotos)
            .Include(u => u.Recipient).ThenInclude(p => p.UserPhotos)
            .Where(m => m.RecipientId == userId && m.SenderId == recipientId && m.RecipientDeleted == false
            || m.RecipientId == recipientId && m.SenderId == userId && m.SenderDeleted == false)
            .OrderByDescending(m => m.DateSent).ToListAsync();

            return messages;
        }
    }
}