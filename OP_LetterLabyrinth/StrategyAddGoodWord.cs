using System;

namespace OP_LetterLabyrinth
{
    public class StrategyAddGoodWord : IWordStrategy
    {
        public void DoOperation(ILetter[] word, Dictionary dictionary)
        {
            var stringWord = Dictionary.StringFromLetters(word);
            Logger.GetInstance().Log("INFO", $"Found good word. {stringWord}");
            dictionary.AddGoodWord(word);
            if (dictionary.WordExistsInPath(word))
            {
                Logger.GetInstance().Log("INFO", $"Found word in path: {stringWord}");
                dictionary.MarkPathWordFound(word);
                GameStatus.GetInstance().ConsumeCurrentWord(true);
            }
            else
            {
                GameStatus.GetInstance().AddPointsForCurrentWord(true);
            }
        }
    }
}