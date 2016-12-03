using System;
using System.IO;

namespace OP_LetterLabyrinth
{
    public class LowestScore : HighScoreProvider
    {
        private readonly string highScoreFile;
        public LowestScore(HighScoreType type)
        {
            Type = type;
            highScoreFile = $"LowestScoreRecord.txt";
            HighScoreValue = File.Exists(highScoreFile) ? File.ReadAllText(highScoreFile) : "10000";
        }

        protected override void SaveHighScore(string value)
        {
            if (int.Parse(HighScoreValue) > int.Parse(value))
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
            return $"Lowest points:{HighScoreValue}";
        }
    }
}