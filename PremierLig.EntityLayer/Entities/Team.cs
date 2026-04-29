using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.EntityLayer.Entities
{
    public class Team
    {
        public int TeamId { get; set; }        
        public string TeamName { get; set; }   // "Manchester City"
        public string ShortName { get; set; }  // "MCI", "LIV", "ARS"
        public string LogoUrl { get; set; }    // Logo resim yolu
        public string StadiumName { get; set; }// "Etihad Stadium"
        public string City { get; set; }       // "Manchester"
        public int? LeagueId { get; set; }
        public League League { get; set; }
        public int? HomeStadiumId { get; set; }
        public Stadium HomeStadium { get; set; }
    }
}
