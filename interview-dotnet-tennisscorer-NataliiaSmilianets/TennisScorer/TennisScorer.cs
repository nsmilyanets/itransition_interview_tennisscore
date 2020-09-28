using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScorer
{
    public class TennisScorer : SportGameScorerConsole
    {
        public TennisScorer() : base("Tennis")
        {
            LastScoreValue = 40;
        }

        public override int GetNextScore(int value)
        {
            switch (value)
            {
                case 0: return 15;
                case 15: return 30;
                case 30: return 40;
            }
            throw new NotSupportedException();
        }
    }
}
