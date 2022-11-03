using DotnetStarter.Logic.BowlingKata;
using Xunit;

namespace DotnetStarter.Logic.Tests.BowlingKata
{
    public class GameTest
    {
        [Fact]
        public void RollingAllZeroesScoresZero()
        {
            Game game = new Game();
            RollMany(game, 0, 20);
            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void RollingAllOnesScoresTwenty()
        {
            Game game = new Game();
            RollMany(game, 1, 20);
            Assert.Equal(20, game.Score());
        }
        
        [Fact]
        public void RollingZeroesAndASpareScoresSixteen()
        {
            Game game = new Game();
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            RollMany(game, 0, 17);
            
            Assert.Equal(16, game.Score());
        }

        [Fact]
        public void RollingZeroesAndAStrikeScoresTwentyFour()
        {
            Game game = new Game();
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);
            RollMany(game, 0, 16);
            
            Assert.Equal(24, game.Score());
        }

        [Fact]
        public void RollingAllStrikesScoresThreeHundred()
        {
            Game game = new Game();
            RollMany(game, 10, 12);
            
            Assert.Equal(300, game.Score());
        }

        private static void RollMany(Game game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
