using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OP_LetterLabyrinth
{
    public class DictionaryReader : IDictionaryReader
    {
        private string[] _words;
        private List<Letter> _letters = new List<Letter>();

        public DictionaryReader( string languageFilePath )
        {
            Logger.GetInstance().Log("INFO", $"Reading dictionary in {languageFilePath}");
            try
            {
                var lines = File.ReadAllLines(languageFilePath, Encoding.UTF8);
                var wordCount = int.Parse(lines.First());
                ReadWords(lines.Skip(1).Take(wordCount).ToArray());
                ReadLetters(lines.Skip(wordCount + 1).ToArray());
            }
            catch (Exception exce)
            {
                Logger.GetInstance().Log("ERROR", $"Failed reading dictionary: {exce}");
            }
        }

        private void ReadWords(string[] lines)
        {
            Logger.GetInstance().Log("INFO", "Reading words");
            _words = lines;
            Logger.GetInstance().Log("INFO", $"{_words.Length} word(s) read");
        }
	
        private void ReadLetters(string[] lines)
        {
            Logger.GetInstance().Log("INFO", "Reading letters");
            _letters = lines.Select(l => new Letter(l.Split()[0], int.Parse(l.Split()[1]), int.Parse(l.Split()[2]))).ToList();
            Logger.GetInstance().Log("INFO", $"{_letters.Count} letter(s) read");
        }

        public string[] GetAllWords()
        {
            return _words;
        }

        public Letter[] GetAllLetters()
        {
            return _letters.ToArray();
        }

    }
}
