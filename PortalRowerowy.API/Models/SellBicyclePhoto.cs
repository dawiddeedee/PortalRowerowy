using System;

namespace PortalRowerowy.API.Models
{
    public class SellBicyclePhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsMain { get; set; }
        public SellBicycle SellBicycle { get; set; }
        public int SellBicycleId { get; set; }
        public string public_id { get; set;}
    }
}