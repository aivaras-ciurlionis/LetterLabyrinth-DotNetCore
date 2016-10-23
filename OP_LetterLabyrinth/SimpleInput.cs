/**
 * @(#) SimpleInput.cs
 */

using System;

namespace OP_LetterLabyrinth
{
    public class SimpleInput : IInput
    {
        public Move GetNewDirection()
        {
            var key = Console.ReadKey();
            var pressedKey = key.Key;
            var move = Move.Up;
            switch (pressedKey)
            {
                case ConsoleKey.UpArrow: move = Move.Up;
                    break;
                case ConsoleKey.RightArrow: move = Move.Right;
                    break;
                case ConsoleKey.DownArrow: move = Move.Down;
                    break;
                case ConsoleKey.LeftArrow: move = Move.Left;
                    break;
                case ConsoleKey.Spacebar: move = Move.Drop;
                    break;
                default: move = Move.Down;
                    break;
            }
            Logger.GetInstance().Log("INFO", $"Goging: {move}");
            return move;
        }
    }
}
