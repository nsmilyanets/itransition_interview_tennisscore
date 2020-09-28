using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisScorer.Tests
{
    public class SimpleGameScorer : SportGameScorer
    {
        public SimpleGameScorer() : base("SimpleGame")
        {
            LastScoreValue = 3;
        }

        public override void DisplayScreen()
        {
        }

        public override int GetNextScore(int value)
        {
            switch (value)
            {
                case 0: return 1;
                case 1: return 2;
                case 2: return 3;
            }
            throw new NotSupportedException();
        }
    }

    public class SimpleGame : SportGame
    {
        public SimpleGame(ISportGameScorer gameScorer) : base("SimpleGame", gameScorer)
        {
        }
    }

    public class GameWinnerDecisionMakerSimpleA : IGameWinnerDecisionMaker
    {
        public string WinnerDecisionMaker()
        {            
            return "A";
        }
    }

    public class GameWinnerDecisionMakerSimpleB : IGameWinnerDecisionMaker
    {
        public string WinnerDecisionMaker()
        {
            return "B";
        }
    }

    [TestClass]
    public class SimpleGameTest
    {
        [TestMethod]
        public void SimpleGameSimpleTest()
        {
            var simpleGame = new SimpleGame(new SimpleGameScorer());

            simpleGame.GameScorer.PlayerAName = "PlayerA";
            simpleGame.GameScorer.PlayerBName = "PlayerB";

            var winner = simpleGame.PlaySportGame(new GameWinnerDecisionMakerSimpleA().WinnerDecisionMaker);
            Assert.IsTrue(winner == "A");

            winner = simpleGame.PlaySportGame(new GameWinnerDecisionMakerSimpleB().WinnerDecisionMaker);
            Assert.IsTrue(winner == "B");
        }
    }
}
