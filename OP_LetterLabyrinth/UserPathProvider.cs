using System;
using System.Collections.Generic;
using System.Globalization;

namespace OP_LetterLabyrinth
{

    public class UserPathProvider : IPathProvider
    {
        private readonly PathCommandInvoker _commandInvoker = new PathCommandInvoker();

        public UserPathProvider()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        private int AnalyseGivenWord(string word, int totalPathLength, Dictionary dictionary)
        {
            PathWordRequest request = new PathWordRequest(word, dictionary);
            int length;
            var isNumber = int.TryParse(word, out length);
            if (isNumber)
            {
                Console.WriteLine($"Random word will be added");
                _commandInvoker.TakeCommand(new RandomWordCommand(request));
                return length;
            }
            else if (word.Length <= totalPathLength && word.Length > 2 &&
                 dictionary.WordExists(dictionary.GetLettersOfWord(word)))
            {
                Console.WriteLine($"Word Accepted");
                _commandInvoker.TakeCommand(new GivenWordCommand(request));
                return word.Length;
            }
            Console.WriteLine($"Word is wrong length or incorrect.");
            Logger.GetInstance().Log("INFO", "Word is with errors!!");
            return 0;
        }

        public IEnumerable<string> GetPathWords(int totalPathLength, Dictionary dictionary)
        {
            Console.WriteLine($"Provide your own list of words.");
            Console.WriteLine($"Keep in mind that total sum of word lengths must be {totalPathLength}");
            Console.WriteLine();
            while (totalPathLength > 0)
            {
                Console.WriteLine($"Provide existing word of max length: {totalPathLength}");
                var word = Console.ReadLine().ToUpper();
                Logger.GetInstance().Log("INFO", $"User provided element for path: {word}");
                if (word.ToUpper() == "U")
                {
                    totalPathLength += _commandInvoker.Undo();
                }
                else
                {
                    totalPathLength -= AnalyseGivenWord(word, totalPathLength, dictionary);
                }
            }
            return _commandInvoker.GetWords();
        }
    }

}