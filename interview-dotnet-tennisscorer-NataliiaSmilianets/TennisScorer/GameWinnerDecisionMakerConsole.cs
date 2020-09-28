using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScorer
{
    public class GameWinnerDecisionMakerConsole : IGameWinnerDecisionMaker
    {
        public string WinnerDecisionMaker()
        {
            Console.Write("Who won? [A / B] (A if empty)? ");
            var winner = Console.ReadLine().Trim().ToUpper();
            return winner;
        }
    }
}
