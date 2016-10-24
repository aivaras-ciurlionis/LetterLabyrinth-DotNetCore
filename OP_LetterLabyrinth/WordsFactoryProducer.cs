using System;

namespace OP_LetterLabyrinth
{
    public class WordsFactoryProducer
    {
        public static AbstractFactory GetFactory(string factory)
        {
            Logger.GetInstance().Log("INFO", $"Requesting factory: {factory}");
            if (factory == nameof(PathProviderFactory))
            {
                return new PathProviderFactory();
            }

            if (factory == nameof(DictionaryReaderFactory))
            {
                return new DictionaryReaderFactory();
            }

            throw new ArgumentException(nameof(factory));
        }
    }
}