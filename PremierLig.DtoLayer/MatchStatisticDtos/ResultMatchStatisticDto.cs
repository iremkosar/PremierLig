using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.DtoLayer.MatchStatisticDtos
{
    public class ResultMatchStatisticDto
    {
        public int MatchStatisticId { get; set; }
        public int FixtureId { get; set; }
        public int FirstHalfHomeGoal { get; set; }
        public int FirstHalfAwayGoal { get; set; }
        public int SecondHalfHomeGoal { get; set; }
        public int SecondHalfAwayGoal { get; set; }
        public int HomePossession { get; set; }
        public int AwayPossession { get; set; }
        public int HomeShots { get; set; }
        public int AwayShots { get; set; }
        public int HomeCorners { get; set; }
        public int AwayCorners { get; set; }
        public int HomeFouls { get; set; }
        public int AwayFouls { get; set; }
        public int HomeOffsides { get; set; }
        public int AwayOffsides { get; set; }
        public int HomeYellowCards { get; set; }
        public int AwayYellowCards { get; set; }
        public int HomeRedCards { get; set; }
        public int AwayRedCards { get; set; }
        public int HomeShotsOnTarget { get; set; }
        public int AwayShotsOnTarget { get; set; }
    }
}
