namespace OP_LetterLabyrinth
{
    public abstract class AbstractLabyrinthGame
    {
        protected abstract void InstanciateGame(LanguageName language,
            IInput input, IGraphics graphics, int sizeX, int sizeY, PathProviderName pathProviderName);
        protected abstract void PerformNextTurn(int turnNumber);
        protected abstract void FinishGame();
        protected abstract bool HasGameFinished();
        
        public void Play(LanguageName languageName, PathProviderName pathProviderName)
        {
            Logger.GetInstance().Log("INFO", $"Setting language: {languageName}");
            InstanciateGame(languageName, new SimpleInput(), new ConsoleGraphics(), 15, 15, pathProviderName);
            var turn = 0;
            while (!HasGameFinished())
            {
                PerformNextTurn(++turn);
            }
            FinishGame();
            Logger.GetInstance().Log("INFO", "Game finished.");
        }
    }
}
