using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.DtoLayer.FixtureDtos
{
    public class CreateFixtureDto
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public DateTime MatchDate { get; set; }
        public int? StadiumId { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public int Status { get; set; }
        public int WeekNumber { get; set; }
        public int? SeasonId { get; set; }
        public string? Referee { get; set; }
        public int? Attendance { get; set; }
    }
}
