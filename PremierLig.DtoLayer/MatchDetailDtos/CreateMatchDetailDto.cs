using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.DtoLayer.MatchDetailDtos
{
    public class CreateMatchDetailDto
    {      
        public int FixtureId { get; set; }
        public int TeamId { get; set; }
        public int Minute { get; set; }
        public string ActionType { get; set; }
        public string Description { get; set; }
    }
}
