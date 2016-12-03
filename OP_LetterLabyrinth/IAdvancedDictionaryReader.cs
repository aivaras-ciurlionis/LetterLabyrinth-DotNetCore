
using System.Collections.Generic;

namespace OP_LetterLabyrinth
{
    public interface IAdvancedDictionaryReader
    {
        void AttachDictionaryFile(string languageFilePath);
        void GetDictionaryItems(out string[] words, out IEnumerable<ILetter> letters);
    }
}