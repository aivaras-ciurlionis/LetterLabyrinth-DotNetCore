using System.Collections.Generic;

namespace OP_LetterLabyrinth
{
    public interface IPathProvider
    {
        IEnumerable<string> GetPathWords(int totalPathLength, Dictionary dictionary);
    }
}