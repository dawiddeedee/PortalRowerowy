using System;
using System.Collections.Generic;
using PortalRowerowy.API.Models;

namespace PortalRowerowy.API.Dtos
{
    public class AdventureForAddDto
    {
        public string adventureName { get; set; }
        public string TypeBicycle { get; set; }
        public int Distance { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserId { get; set; }
        public AdventureForAddDto()
        {
            DateAdded = DateTime.Now;
        }
    }
}