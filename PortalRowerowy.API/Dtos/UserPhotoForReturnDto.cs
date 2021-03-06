using System;

namespace PortalRowerowy.API.Dtos
{
    public class UserPhotoForReturnDto
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsMain { get; set; }

        public string Public_Id { get; set; }

    }
}