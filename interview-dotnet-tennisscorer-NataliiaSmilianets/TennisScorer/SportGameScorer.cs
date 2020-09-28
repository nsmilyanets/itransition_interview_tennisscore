using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScorer
{
    public abstract class SportGameScorer : ISportGameScorer
    {        
        protected List<int[]> _scoreBoard = new List<int[]>();
        protected int[] _currentSetScore = new[] { 0, 0 };
        protected bool _playerAIsServing = true;
        protected bool? _playerAHasAdvantage = null;
        
        protected int LastScoreValue { get; set; }
        public string GameName { get; set; }
        public string PlayerAName { get; set; }
        public string PlayerBName { get; set; }

        public SportGameScorer(string gameName)
        {
            GameName = gameName;
            _scoreBoard.Add(new int[2]);
        }

        public void ChangePlayerServing()
        {
            _playerAIsServing = !_playerAIsServing;
        }

        public abstract void DisplayScreen();

        /// <summary>
        /// Returns true if current game is won.
        /// </summary>
        /// <param name="playerAWins">if set to <c>true</c> [player a wins].</param>
        /// <returns></returns>
        public bool IncreaseScore(bool playerAWins)
        {
            int index = playerAWins ? 0 : 1;
            if (_currentSetScore[0] == LastScoreValue && _currentSetScore[1] == LastScoreValue)
            {
                if ((_playerAHasAdvantage != null && _playerAHasAdvantage.Value && playerAWins) ||
                    (_playerAHasAdvantage != null && !_playerAHasAdvantage.Value && !playerAWins))
                {
                    _playerAHasAdvantage = null;
                    _currentSetScore = new[] { 0, 0 };
                    return true;
                }
                else if (_playerAHasAdvantage != null)
                {
                    _playerAHasAdvantage = null;
                    return false;
                }
                else
                {
                    _playerAHasAdvantage = playerAWins;
                    return false;
                }
            }
            else if (_currentSetScore[index] == LastScoreValue)
            {
                _currentSetScore = new[] { 0, 0 };
                return true;
            }
            else
            {
                _currentSetScore[index] = GetNextScore(_currentSetScore[index]);
                return false;
            }
        }

        public virtual int GetNextScore(int value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if current set is won.
        /// </summary>
        /// <param name="playerAWins">if set to <c>true</c> [player a wins].</param>
        /// <returns></returns>
        public bool CompleteGame(bool playerAWins)
        {
            var currentSet = _scoreBoard.Last();
            var index = playerAWins ? 0 : 1;
            currentSet[index] += 1;
            return (currentSet[index] >= 6 && currentSet[index == 0 ? 1 : 0] < 5) || currentSet[index] == 7;
        }

        public bool CompleteSet()
        {
            var numberOfSetsWonByA = _scoreBoard.Count(a => a[0] > a[1]);
            var numberOfSetsWonByB = _scoreBoard.Count(a => a[0] < a[1]);
            if (numberOfSetsWonByA >= 2 || numberOfSetsWonByB >= 2) return true;

            _scoreBoard.Add(new int[2]);
            return false;
        }
    }
}
