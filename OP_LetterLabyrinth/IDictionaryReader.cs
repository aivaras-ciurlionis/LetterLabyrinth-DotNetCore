/**
 * @(#) IDictionaryReader.cs
 */

namespace OP_LetterLabyrinth
{
    public interface IDictionaryReader
    {
        void ReadFile(string languageFilePath);
        string[] GetAllWords();
        ILetter[] GetAllLetters();
    }
}