using System;
using System.Collections.Generic;

namespace OP_LetterLabyrinth
{

    public class UserPathProvider : IPathProvider
    {
        public UserPathProvider()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        public IEnumerable<string> GetPathWords(int totalPathLength, Dictionary dictionary)
        {
            var words = new List<string>();
            Console.WriteLine($"Provide your own list of words.");
            Console.WriteLine($"Keep in mind that total sum of word lengths must be {totalPathLength}");
            Console.WriteLine();
            while (totalPathLength > 0)
            {
                Console.WriteLine($"Provide existing word of max length: {totalPathLength}");
                var word = Console.ReadLine().ToUpper();
                Logger.GetInstance().Log("INFO", $"User provided word for path: {word}");
                if (word.Length <= totalPathLength && word.Length > 2 &&
                 dictionary.WordExists(dictionary.GetLettersOfWord(word)))
                {
                    words.Add(word);
                    Console.WriteLine($"Word accepted");
                    totalPathLength -= word.Length;
                }
                else
                {
                    Console.WriteLine($"Word is wrong length or incorrect.");
                    Logger.GetInstance().Log("INFO", "Word is with errors!!");
                }
            }
            return words;
        }
    }

}