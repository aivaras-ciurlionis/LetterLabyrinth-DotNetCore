using System;
using System.Collections.Generic;
using System.Linq;

namespace OP_LetterLabyrinth
{
    public class AdvancedDictionaryReaderAdapter : IDictionaryReader
    {
        private readonly IAdvancedDictionaryReader _advancedReader;
        private string[] _words;
        private IEnumerable<ILetter> _letters = new List<ILetter>();

        public AdvancedDictionaryReaderAdapter(IAdvancedDictionaryReader advancedReader)
        {
            _advancedReader = advancedReader;
        }

        public ILetter[] GetAllLetters()
        {
            return _letters.ToArray();
        }

        public string[] GetAllWords()
        {
           return _words;
        }

        public void ReadFile(string languageFilePath)
        {
            _advancedReader.AttachDictionaryFile(languageFilePath);
            _advancedReader.GetDictionaryItems(out _words, out _letters);
        }
    }


}