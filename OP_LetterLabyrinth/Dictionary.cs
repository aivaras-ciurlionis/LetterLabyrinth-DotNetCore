using System;
using System.Collections.Generic;
using System.Linq;

namespace OP_LetterLabyrinth
{
    public class Dictionary
    {
        private readonly Language _language;
        private readonly string[] _words;
        private List<Letter> _letters = new List<Letter>();
        private Random random = new Random();
        private List<FindableWord> _pathWords = new List<FindableWord>();

        public Dictionary(Language language)
        {
            _language = language;
            IDictionaryReader reader = new DictionaryReader(_language.GetDictionaryLocation());
            _words = reader.GetAllWords();
            _letters.AddRange(reader.GetAllLetters().ToList());
        }

        public void AddPathWord(Letter[] word)
        {
            var pathWord = new FindableWord(StringFromLetters(word), word.Sum(w => w.GetPoints()), false);
            _pathWords.Add(pathWord);
        }

        public bool WordExistsInPath(Letter[] word)
        {
            var stringWord = StringFromLetters(word).ToUpper();
            var foundWord = _pathWords.FirstOrDefault(w => !w.IsFound() && w.GetWord() == stringWord);
            if (foundWord == null)
            {
                return false;
            }
            foundWord.MarkFound();
            return true;
        }

        public bool WordFragmentExistsInPath(Letter[] word)
        {
            var stringWord = StringFromLetters(word).ToUpper();
            return _pathWords.Any(w => !w.IsFound() && w.GetWord().StartsWith(stringWord));
        }

        public bool WordExists(Letter[] word)
        {
            var stringWord = StringFromLetters(word).ToLower();
            return _words.Any(w => w == stringWord);
        }

        public bool AnyWordBeginsWith(Letter[] fragment)
        {
            var stringFragment = StringFromLetters(fragment).ToLower();
            return _words.Any(w => w.StartsWith(stringFragment));
        }

        public string[] GetAllPathWords()
        {
            return _pathWords.Select(w => w.ToString()).ToArray();
        }

        public string GetAnyWordOfLength(int length)
        {
            var possibleWords = _words.Where(w => w.Length == length);
            var enumerable = possibleWords as string[] ?? possibleWords.ToArray();
            var word = enumerable.ElementAt(random.Next(enumerable.Length)).ToUpper();
            Logger.GetInstance().Log("INFO", $"Getting word of {length} length: {word}");
            return word;
        }

        public Language GetLanguage()
        {
            return _language;
        }

        public Letter[] GetLettersOfWord(string word)
        {
            Logger.GetInstance().Log("INFO", $"Getting letters of word: {word}");
            return word.Select(letter => _letters.First(l => l.GetName() == letter.ToString())).ToArray();
        }

        public static string StringFromLetters(Letter[] letters)
        {
            return letters.Aggregate("", (s, letter) => s += letter.GetName());
        }

        public Letter[] GetLetters()
        {
            return _letters.ToArray();
        }
    }
}
