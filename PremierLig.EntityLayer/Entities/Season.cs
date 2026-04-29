using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.EntityLayer.Entities
{
    public class Season
    {
        public int SeasonId { get; set; }
        public int LeagueId { get; set; }
        public League League { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCurrent { get; set; }
        public List<Fixture> Fixtures { get; set; }
    }
}
