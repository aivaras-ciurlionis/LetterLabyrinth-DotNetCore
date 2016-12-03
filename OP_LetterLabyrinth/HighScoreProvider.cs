namespace OP_LetterLabyrinth
{
    public enum HighScoreType
    {
        HIGHEST_SCORE = 0,
        LOWEST_SCORE = 1,
        LONGEST_WORD = 2
    };

    public abstract class HighScoreProvider
    {
        protected HighScoreType Type;
        protected HighScoreProvider NextProvider;
        protected string HighScoreValue;

        public void SetNextProvider(HighScoreProvider provider)
        {
            NextProvider = provider;
        }

        public void SetHighScore(HighScoreType type, string value)
        {
            if (type == Type)
            {
                SaveHighScore(value);
            }
            else
            {
                NextProvider?.SetHighScore(type, value);
            }
        }

        public string GetHighScore(HighScoreType type)
        {
            if (type == Type)
            {
                return ExtractHighScore();
            }
            else
            {
                return NextProvider?.GetHighScore(type);
            }
        }
        protected abstract void SaveHighScore(string value);
        protected abstract string ExtractHighScore();
    }
}