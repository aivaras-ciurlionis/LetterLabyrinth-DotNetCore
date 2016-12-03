using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OP_LetterLabyrinth
{
    public class LTDictionaryReader : IAdvancedDictionaryReader
    {
        string[] lines;
        int wordCount;
        private string[] ReadWords(string[] lines)
        {
            var words = new string[lines.Length];
            Logger.GetInstance().Log("INFO", "Reading words");
            words = lines.Select(l => l.Split('\t')[2]).ToArray();
            Logger.GetInstance().Log("INFO", $"{words.Count()} word(s) read");
            return words;
        }

        private IEnumerable<ILetter> ReadLetters(string[] lines)
        {
            Logger.GetInstance().Log("INFO", "Reading letters");
            var letters = lines.Select(l => new Letter(l.Split()[0], int.Parse(l.Split()[1]), int.Parse(l.Split()[2]))).ToList();
            Logger.GetInstance().Log("INFO", $"{letters.Count()} letter(s) read");
            return letters;
        }

        public void AttachDictionaryFile(string languageFilePath)
        {
            Logger.GetInstance().Log("INFO", $"Reading ADVANCED LT dictionary");
            Logger.GetInstance().Log("INFO", $"Reading dictionary in {languageFilePath}");
            try
            {
                lines = File.ReadAllLines(languageFilePath, Encoding.UTF8);
                wordCount = int.Parse(lines.First());
            }
            catch (Exception exce)
            {
                Logger.GetInstance().Log("ERROR", $"Failed reading ADVANCED dictionary: {exce}");
            }
        }

        public void GetDictionaryItems(out string[] words, out IEnumerable<ILetter> letters)
        {
            words = ReadWords(lines.Skip(1).Take(wordCount).ToArray());
            letters = ReadLetters(lines.Skip(wordCount + 1).ToArray());
        }
    }
}
