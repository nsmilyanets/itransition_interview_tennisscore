using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScorer
{
    public class SportGameScorerConsole : SportGameScorer
    {
        public SportGameScorerConsole(string gameName) 
            : base(gameName)
        {
        }

        public override void DisplayScreen()
        {
            Console.Clear();
            if (_playerAIsServing) Console.Write("*");
            if (_playerAHasAdvantage != null && _playerAHasAdvantage.Value) Console.Write("!");
            Console.WriteLine(string.Format("{0}:\t{1}\t| {2}",
                PlayerAName,
                string.Join(" ", _scoreBoard.Select(t => t[0])),
                _currentSetScore[0]));

            if (!_playerAIsServing) Console.Write("*");
            if (_playerAHasAdvantage != null && !_playerAHasAdvantage.Value) Console.Write("!");
            Console.WriteLine(string.Format("{0}:\t{1}\t| {2}",
                PlayerBName,
                string.Join(" ", _scoreBoard.Select(t => t[1])),
                _currentSetScore[1]));
            Console.WriteLine();
        }
        
    }
}
