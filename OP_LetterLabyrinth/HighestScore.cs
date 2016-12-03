using System.IO;

namespace OP_LetterLabyrinth
{
    public class HighestScore : HighScoreProvider
    {
        private readonly string highScoreFile;
        public HighestScore(HighScoreType type)
        {
            Type = type;
            highScoreFile = $"HighestScoreRecord.txt";
            HighScoreValue = File.Exists(highScoreFile) ? File.ReadAllText(highScoreFile) : "-999999";
        }

        protected override void SaveHighScore(string value)
        {
            if (int.Parse(HighScoreValue) < int.Parse(value))
            {
                using (StreamWriter w = File.CreateText(highScoreFile))
                {
                    w.WriteLine($"{value}");
                }
                HighScoreValue = value;
            }
        }

        protected override string ExtractHighScore()
        {
            return $"Highest points:{HighScoreValue}";
        }

    }
}