namespace BowlingGame.Tests
{
    public class GameTests
    {
        [Fact]
        public void Should_Score_WhenRoll()
        {
            var game = new Game();

            for (var i = 1; i <= 20; i++)
            {
                game.Roll(1);
            }

            Assert.Equal(20, game.Score);
        }

        [Fact]
        public void Should_Strike_WhenPinIs10InTheFirstAttempt()
        {
            var game = new Game();

            game.Roll(10);
            game.Roll(4);
            game.Roll(5);

            Assert.Equal(28, game.Score);
        }

        [Fact]
        public void Should_Spare_WhenTotalFrameScoreIs10InSecondAttempt()
        {
            var game = new Game();

            game.Roll(4);
            game.Roll(6);
            game.Roll(10);

            Assert.Equal(20, game.Score);
        }

        [Fact]
        public void ShouldNot_NotScore_WhenPinsIsSuperiorTo10()
        {
            var game = new Game();

            game.Roll(11);

            Assert.Equal(0, game.Score);
        }

        [Fact]
        public void ShouldNot_NotScore_WhenPinsIsInferiorTo0()
        {
            var game = new Game();

            game.Roll(-1);

            Assert.Equal(0, game.Score);
        }

        [Fact]
        public void ShouldNot_NotScore_WhenTotalScoreIsSuperiorTo10OnSecondRoll()
        {
            var game = new Game();

            game.Roll(4);
            game.Roll(7);

            Assert.Equal(4, game.Score);
        }

        [Fact]
        public void Should_NotScore_WhenGameIsOver()
        {
            var game = new Game();

            for (var i = 1; i <= 20; i++)
            {
                game.Roll(1);
            }

            game.Roll(5);

            Assert.Equal(20, game.Score);
        }

        [Fact]
        public void Should_NotScore_WhenMoreThan3AttempsOnLastFrame()
        {
            var game = new Game();

            for (var i = 1; i <= 18; i++)
            {
                game.Roll(1);
            }

            game.Roll(10);
            game.Roll(2);
            game.Roll(2);
            game.Roll(3);

            Assert.Equal(32, game.Score);
        }
    }
}