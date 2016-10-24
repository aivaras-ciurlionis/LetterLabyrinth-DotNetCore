using System;

namespace OP_LetterLabyrinth
{
    public class StrategyDropWord : IWordStrategy
    {
        public void DoOperation(Letter[] word, Dictionary dictionary)
        {
            var stringWord = Dictionary.StringFromLetters(word);
            Logger.GetInstance().Log("INFO", $"Dropping word. {stringWord}");
            var exists = dictionary.WordExists(word);
            if (exists)
            {
                dictionary.AddGoodWord(word);
            }
            else
            {
                dictionary.AddBadWord(word);
            }
            GameStatus.GetInstance().ConsumeCurrentWord(exists);
        }
    }
}