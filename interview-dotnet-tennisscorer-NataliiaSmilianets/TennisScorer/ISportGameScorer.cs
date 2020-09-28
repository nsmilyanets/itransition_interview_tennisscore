using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScorer
{
    public interface ISportGameScorer
    {
        string GameName { get; set; }
        string PlayerAName { get; set; }
        string PlayerBName { get; set; }
        void ChangePlayerServing();
        void DisplayScreen();
        bool IncreaseScore(bool playerAWins);
        int GetNextScore(int value);
        bool CompleteGame(bool playerAWins);
        bool CompleteSet();
    }
}
