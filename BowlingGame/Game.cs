namespace BowlingGame
{
    public class Game
    {
        private Dictionary<int, int> frameStrike = new Dictionary<int, int>();
        private int[] frameScore = new int[10];
        private int rolls = 1;
        private int currentFrame = 1;

        public void Roll(int pins)
        {
            if (currentFrame > 10)
                return;

            frameScore[currentFrame - 1] += pins;

            foreach (var (key, value) in frameStrike)
            {
                frameScore[key] += pins;

                if (value == 2)
                    frameStrike[key] = value - 1;
                else
                    frameStrike.Remove(key);
            }

            if (pins == 10)
            {
                if (rolls == 1)
                {
                    if (currentFrame < 10)
                    {
                        frameStrike.Add(currentFrame - 1, 2);
                        currentFrame++;
                    }
                }
                else
                {
                    if (rolls == 3)
                    {
                        currentFrame++;
                        rolls = 1;
                    }
                    else
                        rolls++;
                }

                return;
            }

            rolls++;

            if (rolls > 2)
            {
                rolls = 1;
                currentFrame++;
            }
        }

        public int Score
        {
            get
            {
                return frameScore.Sum();
            }
        }

        public override string ToString()
        {
            string scoresPerFrame = $"Frame 1 : {frameScore[0]} {Environment.NewLine}" +
                $"Frame 2 : {frameScore[1]} {Environment.NewLine}" +
                $"Frame 3 : {frameScore[2]} {Environment.NewLine}" +
                $"Frame 4 : {frameScore[3]} {Environment.NewLine}" +
                $"Frame 5 : {frameScore[4]} {Environment.NewLine}" +
                $"Frame 6 : {frameScore[5]} {Environment.NewLine}" +
                $"Frame 7 : {frameScore[6]} {Environment.NewLine}" +
                $"Frame 8 : {frameScore[7]} {Environment.NewLine}" +
                $"Frame 9 : {frameScore[8]} {Environment.NewLine}" +
                $"Frame 10 : {frameScore[9]} {Environment.NewLine}";


            return scoresPerFrame;
        }
    }
}