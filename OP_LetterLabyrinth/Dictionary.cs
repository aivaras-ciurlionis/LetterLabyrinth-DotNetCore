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
        private List<FindableWord> _goodWords = new List<FindableWord>();
        private List<FindableWord> _badWords = new List<FindableWord>();

        public Dictionary(Language language)
        {
            _language = language;

            IDictionaryReader reader;

            reader = WordsFactoryProducer.GetFactory(nameof(DictionaryReaderFactory))
                          .GetDictionaryReader($"{_language.GetLanguageName()}DictionaryReader");

            reader.ReadFile(_language.GetDictionaryLocation());
            _words = reader.GetAllWords();
            _letters.AddRange(reader.GetAllLetters().ToList());
        }

        public void AddPathWord(Letter[] word)
        {
            var pathWord = new FindableWord(StringFromLetters(word), word.Sum(w => w.GetPoints()), false);
            _pathWords.Add(pathWord);
        }

        public void AddGoodWord(Letter[] word)
        {
            var goodWord = new FindableWord(StringFromLetters(word), word.Sum(w => w.GetPoints()), false);
            _goodWords.Add(goodWord);
        }

        public void AddBadWord(Letter[] word)
        {
            var badWord = new FindableWord(StringFromLetters(word), word.Sum(w => w.GetPoints()), false);
            _badWords.Add(badWord);
        }

        public void MarkPathWordFound(Letter[] word)
        {
            var stringWord = StringFromLetters(word).ToUpper();
            Logger.GetInstance().Log("INFO", $"Marking path word found: {stringWord}");
            var foundWord = _pathWords.FirstOrDefault(w => !w.IsFound() && w.GetWord() == stringWord);
            if (foundWord != null)
            {
                foundWord.MarkFound();
            }
        }

        public bool WordExistsInPath(Letter[] word)
        {
            var stringWord = StringFromLetters(word).ToUpper();
            Logger.GetInstance().Log("INFO", $"Checking for word {stringWord} existance in path");
            var foundWord = _pathWords.FirstOrDefault(w => !w.IsFound() && w.GetWord() == stringWord);
            Logger.GetInstance().Log("INFO", $"Result: {foundWord}");
            return foundWord != null;
        }

        public bool WordFragmentExistsInPath(Letter[] word)
        {
            var stringWord = StringFromLetters(word).ToUpper();
            Logger.GetInstance().Log("INFO", $"Checking for word fragment {stringWord} existance in path");
            var result = _pathWords.Any(w => !w.IsFound() && w.GetWord().StartsWith(stringWord));
            Logger.GetInstance().Log("INFO", $"Result:{result}");
            return result;
        }

        public bool WordExists(Letter[] word)
        {
            var stringWord = StringFromLetters(word).ToLower();
            Logger.GetInstance().Log("INFO", $"Checking word {stringWord} for existance");
            var result = _words.Any(w => w == stringWord);
            Logger.GetInstance().Log("INFO", $"Result:{result}");
            return result;
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

        public string[] GetAllGoodWords()
        {
            return _goodWords.Select(w => w.ToString()).ToArray();
        }

        public string[] GetAllBadWords()
        {
            return _badWords.Select(w => w.ToStringNegative()).ToArray();
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
