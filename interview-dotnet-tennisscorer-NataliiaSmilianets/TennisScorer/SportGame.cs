using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScorer
{
    public abstract class SportGame : ISportGame
    {
        private readonly ISportGameScorer _gameScorer;
        public ISportGameScorer GameScorer {
            get
            {
                return _gameScorer;
            }
        }

        public string GameName { get; set; }
        public SportGame(string gameName, ISportGameScorer gameScorer)
        {
            GameName = gameName;
            _gameScorer = gameScorer;
        }

        public string PlaySportGame(Func<string> winnerDesicionMaker)
        {
            var winner = string.Empty;
            while (true)
            {
                _gameScorer.DisplayScreen();                
                winner = winnerDesicionMaker();
                bool gameCompleted = false;
                bool gameOver = false;
                switch (winner)
                {
                    case "":
                    case "A":
                        gameCompleted = _gameScorer.IncreaseScore(true);
                        if (gameCompleted)
                            if (_gameScorer.CompleteGame(true))
                                gameOver = _gameScorer.CompleteSet();
                        break;
                    case "B":
                        gameCompleted = _gameScorer.IncreaseScore(false);
                        if (gameCompleted)
                            if (_gameScorer.CompleteGame(true))
                                gameOver = _gameScorer.CompleteSet();
                        break;
                    case "E":
                    case "e":
                        return winner;
                    default:
                        continue;
                }
                if (gameOver) break;
                _gameScorer.ChangePlayerServing();
            }

            _gameScorer.DisplayScreen();

            return winner;
        }

    }
}
