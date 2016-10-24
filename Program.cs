using System;

namespace OP_LetterLabyrinth
{
    class Program
    {
        private static void Main(string[] args)
        {
            Logger.GetInstance().Log("INFO", "Program is starting");
            var game = new GameController();
            game.InstanciateGame(LanguageName.Lt, new SimpleInput(), new ConsoleGraphics(), 15, 15);
            var turn = 0;
            while (!game.HasGameFinished())
            {
                turn++;
                game.PerformNextTurn(turn);
            }
            game.FinishGame();
            Logger.GetInstance().Log("INFO", "Game finished.");
            Console.ReadKey();
        }
    }
}
