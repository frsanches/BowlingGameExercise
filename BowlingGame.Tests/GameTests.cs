namespace BowlingGame.Tests
{
    public class GameTests
    {
        [Fact]
        public void Should_Roll_Score()
        {
            var game = new Game();

            for (var i = 1; i <= 20; i++)
            {
                game.Roll(1);
            }

            Assert.Equal(20, game.Score);
        }

        [Fact]
        public void Should_Roll_Strike()
        {
            var game = new Game();

            game.Roll(10);

            for (var i= 1; i <= 18; i++)
            {
                game.Roll(2);
            }

            Assert.Equal(50, game.Score);
        }

        [Fact]
        public void Should_Roll_Spare()
        {
            var game = new Game();

            game.Roll(4);
            game.Roll(6);
            game.Roll(10);

            for (var i = 1; i <= 18; i++)
            {
                game.Roll(2);
            }

            Assert.Equal(56, game.Score);
        }
    }
}