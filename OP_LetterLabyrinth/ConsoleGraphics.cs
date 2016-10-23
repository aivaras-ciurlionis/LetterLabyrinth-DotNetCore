/**
 * @(#) ConsoleGraphics.cs
 */

using System;

namespace OP_LetterLabyrinth
{
    public class ConsoleGraphics : IGraphics
    {
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
