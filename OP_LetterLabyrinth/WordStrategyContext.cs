namespace OP_LetterLabyrinth
{
    public class WordStrategyContext
    {
        private readonly IWordStrategy _strategy;

        public WordStrategyContext(IWordStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteStrategy(ILetter[] word, Dictionary dictionary)
        {
            _strategy.DoOperation(word, dictionary);
        }
    }
}