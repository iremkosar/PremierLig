using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLig.EntityLayer.Entities
{
    public class MatchDetail
    {
        public int MatchDetailId { get; set; }
        public int FixtureId { get; set; }    // Hangi maça ait olduğu
        public int Minute { get; set; }       // Olayın dakikası (23', 67' gibi)
        public string ActionType { get; set; }// "Goal","YellowCard","RedCard","Substitution"
        public string Description { get; set; }// "Haaland sağdan ceza sahasına girdi..."
        public int TeamId { get; set; } // Olayın hangi takıma ait olduğu
    }
}
