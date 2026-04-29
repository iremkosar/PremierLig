using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.DtoLayer.TeamDtos
{
    public class CreateTeamDto
    {
        public string TeamName { get; set; }
        public string ShortName { get; set; }
        public string LogoUrl { get; set; }
        public string StadiumName { get; set; }
        public string City { get; set; }
    }
}
