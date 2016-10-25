/**
 * @(#) GameController.cs
 */

namespace OP_LetterLabyrinth
{
    public class GameController
    {
        private LetterGrid _currentGrid;
        private Player _currentPlayer;
        private IInput _input;
        private IGraphics _graphics;
        private Dictionary _currentDictionary;
        private int _sizeX;
        private int _sizeY;

        public void InstanciateGame(LanguageName language,
            IInput input, IGraphics graphics, int sizeX, int sizeY, PathProviderName pathProviderName)
        {
            Logger.GetInstance().Log("INFO", $"Starting game. Grid: {sizeX}:{sizeY}. Language : {language}");
            var lang = new Language(language, language + "_dictionary.txt");
            ResetGameStatus(lang);
            _currentDictionary = new Dictionary(lang);
            _currentPlayer = new Player(new Point { X = -1, Y = 0 });
            _sizeX = sizeX;
            _sizeY = sizeY;
            _currentGrid = new LetterGrid(sizeX, sizeY, new SmartGridFiller(_currentDictionary, pathProviderName));
            _input = input;
            _graphics = graphics;
            _graphics.DrawTurn(_currentPlayer, _currentGrid, _currentDictionary);
        }

        private static void ResetGameStatus(Language language)
        {
            Logger.GetInstance().Log("INFO", "Reseting game");
            GameStatus.GetInstance().ClearCurrentWord();
            GameStatus.GetInstance().ResetPoints();
            GameStatus.GetInstance().SetLanguage(language);
        }

        private Move GetAndValidatedMove()
        {
            var moveIsValid = false;
            Move move;
            do
            {
                move = _input.GetNewDirection();
                var playerPosiftionAfterMove = _currentPlayer.GetPositionAfterMove(move);
                moveIsValid = _currentGrid.PointIsInGrid(playerPosiftionAfterMove);
            } while (!moveIsValid);
            return move;
        }

        public void PerformNextTurn(int turnNumber)
        {
            Logger.GetInstance().Log("INFO", $"Performing turn {turnNumber}");
            var move = GetAndValidatedMove();
            var position = _currentPlayer.Move(move);
            WordStrategyContext context = null;
            Letter[] currentWord;
            if (move == Move.Drop)
            {
                currentWord = GameStatus.GetInstance().GetCurrentWord();
                context = new WordStrategyContext(new StrategyDropWord());
                context.ExecuteStrategy(currentWord, _currentDictionary);
            }
            else
            {
                var letter = _currentGrid.ConsumeLetterAt(position);
                GameStatus.GetInstance().AddLetter(letter);
                currentWord = GameStatus.GetInstance().GetCurrentWord();
                if (_currentDictionary.WordExists(currentWord) && currentWord.Length > 2)
                {
                    context = new WordStrategyContext(new StrategyAddGoodWord());
                    context.ExecuteStrategy(currentWord, _currentDictionary);
                }
                if (!_currentDictionary.AnyWordBeginsWith(currentWord))
                {
                    context = new WordStrategyContext(new StrategyAddBadWord());
                    context.ExecuteStrategy(currentWord, _currentDictionary);
                    // Extra points removed for not dropping bad word
                    GameStatus.GetInstance().AddPoints(-2 * currentWord.Length);
                }
            }
            _graphics.DrawTurn(_currentPlayer, _currentGrid, _currentDictionary);
        }

        public void FinishGame()
        {
            Logger.GetInstance().Log("INFO", "Ending game");
            _graphics.DrawVictory(_currentDictionary);
        }

        public bool HasGameFinished()
        {
            var playerPosition = _currentPlayer.GetPosition();
            return playerPosition.X >= _sizeX - 1 || playerPosition.Y >= _sizeY - 1;
        }
    }
}
