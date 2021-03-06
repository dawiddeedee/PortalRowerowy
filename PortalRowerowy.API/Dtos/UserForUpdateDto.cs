using System.Collections.Generic;

namespace PortalRowerowy.API.Dtos
{
    public class UserForUpdateDto
    {
        //PODSTAWOWE INFORMACJE O UŻYTKOWNIKU
        //public string Gender { get; set; }
        // public int Age { get; set; }
        public string TypeBicycle { get; set; }
        public string Country { get; set; }
        public string Voivodeship { get; set; }
        //public string County { get; set; }
        public string City { get; set; }
        //DODATKOWE INFORMACJE - ZAKŁADKA INFO
        public string Bicycles { get; set; }
        public string Profession { get; set; }
        //ZAKŁADKA O MNIE
        public string Description { get; set; }
        //Zakładka PASJE, ZAINTERESOWANIE
        public string Interests { get; set; }
        public string DreamBicycle { get; set; }

      /*  //ZAKŁADKA ZDJĘCIA
        public ICollection<UserPhotosForDetailedDto> UserPhotos { get; set; }
        //Zakładka Ogłoszenia
        public ICollection<SellBicycleForDetailedDto> SellBicycles { get; set; }
        //ZAKŁADKA WYPRAWY
        public ICollection<AdventureForDetailedDto> Adventures { get; set; }

        public string PhotoUrl { get; set; }*/
    }
}