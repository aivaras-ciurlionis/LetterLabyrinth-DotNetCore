using System;

namespace OP_LetterLabyrinth
{
    public class DictionaryReaderFactory : AbstractFactory
    {
        public override IDictionaryReader GetDictionaryReader(string reader)
        {
            Logger.GetInstance().Log("INFO", $"Getting dictionary reader: {reader}");

            if (reader == nameof(LTDictionaryReader))
            {
                return new LTDictionaryReader();
            }

            if (reader == nameof(ENDictionaryReader))
            {
                return new ENDictionaryReader();
            }

            throw new ArgumentException(nameof(reader));
        }

        public override IPathProvider GetPathWordsProvider(string provider)
        {
            return null;
        }
    }

}