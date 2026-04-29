using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.EntityLayer.Entities
{
    public class MatchStatistic
    {
        public int MatchStatisticId { get; set; }
        public int FixtureId { get; set; }          // Hangi maça ait
        public int FirstHalfHomeGoal { get; set; }  // İlk yarı ev sahibi golü
        public int FirstHalfAwayGoal { get; set; }  // İlk yarı deplasman golü
        public int SecondHalfHomeGoal { get; set; } // İkinci yarı ev sahibi golü
        public int SecondHalfAwayGoal { get; set; } // İkinci yarı deplasman golü
        public int HomePossession { get; set; }     // Ev sahibi top hakimiyeti (%)
        public int AwayPossession { get; set; }     // Deplasman top hakimiyeti (%)
        public int HomeShots { get; set; }          // Ev sahibi şut sayısı
        public int AwayShots { get; set; }          // Deplasman şut sayısı
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
