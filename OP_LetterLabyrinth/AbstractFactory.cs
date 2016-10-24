namespace OP_LetterLabyrinth
{
    public abstract class AbstractFactory
    {
        public abstract IPathProvider GetPathWordsProvider(string provider);
        public abstract IDictionaryReader GetDictionaryReader(string reader);
    }
}