using System;

namespace PortalRowerowy.API.Models
{
    public class PhotoAdventure
    {
        
        public int Id { get; set; }

        public string Url { get; set; }
        
        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsMain { get; set; }
    }
}