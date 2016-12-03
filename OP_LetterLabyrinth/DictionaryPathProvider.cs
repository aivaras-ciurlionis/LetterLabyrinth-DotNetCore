using System.Collections.Generic;

namespace OP_LetterLabyrinth
{
    public class DictionaryPathProvider : IPathProvider
    {
        private List<int> SplitIntoFixedSizes(int count, int minSize, int maxSize)
        {
            var reminder = count % maxSize;
            var chunks = new List<int>();
            while (reminder > 0 && reminder < minSize)
            {
                maxSize--;
                reminder = count % maxSize;
            }
            var chunkCount = count / maxSize;
            for (var i = 0; i < chunkCount; i++)
            {
                chunks.Add(maxSize);
            }
            if (reminder > 0)
            {
                chunks.Add(reminder);
            }
            return chunks;
        }

        public IEnumerable<string> GetPathWords(int totalPathLength, Dictionary dictionary)
        {
            var words = new List<string>();
            var sizes = SplitIntoFixedSizes(totalPathLength, 4, 8);
            foreach (var size in sizes)
            {
                words.Add(dictionary.GetAnyWordOfLength(size));
            }
            return words;
        }
    }
}