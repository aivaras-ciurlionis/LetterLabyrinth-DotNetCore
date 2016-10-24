/**
 * @(#) ConsoleGraphics.cs
 */

using System;
using System.Text;

namespace OP_LetterLabyrinth
{
    public class ConsoleGraphics : IGraphics
    {
        public ConsoleGraphics ()
        {
          Console.OutputEncoding = Encoding.UTF8;
        }

        public void DrawTurn(Player player, LetterGrid grid, Dictionary dictionary)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(grid.ToString());
            Console.WriteLine();
            Console.WriteLine(GameStatus.GetInstance().ToString());
            Console.WriteLine();
            var pathWords = dictionary.GetAllPathWords();
            foreach (var word in pathWords)
            {
                if (word.StartsWith("*"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                Console.WriteLine(word);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(player.GetPosition().Y * 2, player.GetPosition().X + 1);
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(36, 0);
            Console.WriteLine("Words found:");
            var goodWords = dictionary.GetAllGoodWords();
            for (var i = 0; i < goodWords.Length; i++)
            {
                Console.SetCursorPosition(36, i + 1);
                Console.Write(goodWords[i]);
            }

            Console.SetCursorPosition(60, 0);
            Console.WriteLine("Bad words:");
            var badWords = dictionary.GetAllBadWords();
            for (var i = 0; i < badWords.Length; i++)
            {
                Console.SetCursorPosition(60, i + 1);
                Console.Write(badWords[i]);
            }
            Console.SetCursorPosition(0, 0);

        }

        public void DrawVictory(Dictionary dictionary)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Victory!!!");
            Console.WriteLine(GameStatus.GetInstance().ToString());
            Console.WriteLine();
            var pathWords = dictionary.GetAllPathWords();
            foreach (var word in pathWords)
            {
                if (word.StartsWith("*"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                Console.WriteLine(word);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
        }

    }
}
