using System;

namespace OP_LetterLabyrinth
{
    public class DictionaryReaderFactory : AbstractFactory
    {
        public override IDictionaryReader GetDictionaryReader(string reader)
        {
            Logger.GetInstance().Log("INFO", $"Getting dictionary reader: {reader}");

            if (reader == nameof(LtDictionaryReader))
            {
                return new LtDictionaryReader();
            }

            if (reader == nameof(EnDictionaryReader))
            {
                return new EnDictionaryReader();
            }

            throw new ArgumentException(nameof(reader));
        }

        public override IPathProvider GetPathWordsProvider(string provider)
        {
            return null;
        }
    }

}