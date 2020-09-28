using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScorer
{
    class Program
    {
        static void Main(string[] args)
        {            
            var tennisGame = new TennisGame(new TennisScorer());

            Console.Write("Name of player A: ");
            tennisGame.GameScorer.PlayerAName = Console.ReadLine();
            if (string.IsNullOrEmpty(tennisGame.GameScorer.PlayerAName))
            {
                Console.WriteLine("Empty name!");
                return;
            }

            Console.Write("Name of player B: ");
            tennisGame.GameScorer.PlayerBName = Console.ReadLine();
            if (string.IsNullOrEmpty(tennisGame.GameScorer.PlayerBName))
            {
                Console.WriteLine("Empty name!");
                return;
            }

            tennisGame.PlaySportGame(new GameWinnerDecisionMakerConsole().WinnerDecisionMaker);
            Console.WriteLine("Game over.");
            Console.ReadLine();
        }

        

    }
}
