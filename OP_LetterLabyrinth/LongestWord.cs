using System.IO;

namespace OP_LetterLabyrinth
{
    public class LongestWord : HighScoreProvider
    {
        private readonly string highScoreFile;
        public LongestWord(HighScoreType type)
        {
            Type = type;
            highScoreFile = $"LongestWordRecord.txt";
            HighScoreValue = File.Exists(highScoreFile) ? File.ReadAllText(highScoreFile) : "A";
        }

        protected override void SaveHighScore(string value)
        {
            if (HighScoreValue.Length < value.Length)
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
            return $"Longest word: {HighScoreValue}";
        }
    }
}