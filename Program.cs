using System;

namespace OP_LetterLabyrinth
{
    class Program
    {
        private static LanguageName GetLanguageFromArguments(string[] args)
        {
            if (args.Length > 0)
            {
                try
                {
                    var languageName = (LanguageName)Enum.Parse(typeof(LanguageName), args[0].ToUpper());
                    return languageName;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine($"No such language: {args[0]}");
                    Logger.GetInstance().Log("ERROR", exception.ToString());
                    Environment.Exit(1);
                }
            }
            return LanguageName.EN;
        }

        private static PathProviderName GetPathProviderFromArguments(string[] args)
        {
            if (args.Length > 1)
            {
                try
                {
                    var pathProviderName = (PathProviderName)Enum.Parse(typeof(PathProviderName), args[1]);
                    return pathProviderName;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine($"No such path provider: {args[1]}");
                    Logger.GetInstance().Log("ERROR", exception.ToString());
                    Environment.Exit(1);
                }
            }
            return PathProviderName.Dictionary;
        }

        private static void Main(string[] args)
        {
            Logger.GetInstance().Log("INFO", "Program is starting");
            var languageName = GetLanguageFromArguments(args);
            var pathProviderName = GetPathProviderFromArguments(args);
            AbstractLabyrinthGame game = new GameController();
            game.Play(languageName, pathProviderName);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
