using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScorer
{
    public class TennisGame : SportGame
    {
        public TennisGame(ISportGameScorer gameScorer) : base("Tennis", gameScorer)
        {
        }
    }
}
