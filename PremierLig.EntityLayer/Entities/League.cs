using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.EntityLayer.Entities
{
    public class League
    {
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<Season> Seasons { get; set; }
        public List<Team> Teams { get; set; }
    }
}
