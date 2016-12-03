using System;
using System.Collections.Generic;
using System.Linq;

namespace OP_LetterLabyrinth
{
    public class WordLetterProvider
    {

        private readonly List<ILetter> _letters;

        public WordLetterProvider(List<ILetter> letters)
        {
            _letters = letters;
        }

        private ILetter GetLetter(string character)
        {
            for (var i = 0; i < _letters.Count; i++)
            {
                if (_letters[i].GetName() == character)
                {
                    return _letters[i];
                }
            }
            Logger.GetInstance().Log("INFO", $"Adding null letter. Character not found: {character}");
            Console.WriteLine("Null letter!"); 
            return new NullLetter();
        }

        public ILetter[] GetWordLetters(string word)
        {
            Logger.GetInstance().Log("INFO", $"Getting letters of word: {word}");
            var letters = new ILetter[word.Length];
            for (var i = 0; i < word.Length; i++)
            {
                letters[i] = GetLetter(word.ElementAt(i).ToString());
            }
            return letters;
        }

    }
}