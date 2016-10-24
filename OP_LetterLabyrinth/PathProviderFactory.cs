using System;

namespace OP_LetterLabyrinth
{
    public class PathProviderFactory : AbstractFactory
    {
        public override IDictionaryReader GetDictionaryReader(string reader)
        {
            return null;
        }

        public override IPathProvider GetPathWordsProvider(string provider)
        {
            Logger.GetInstance().Log("INFO", $"Getting path words provider: {provider}");
            if (provider == nameof(UserPathProvider))
            {
                return new UserPathProvider();
            }

            if (provider == nameof(DictionaryPathProvider))
            {
                return new DictionaryPathProvider();
            }

            throw new ArgumentException(nameof(provider));
        }
    }

}