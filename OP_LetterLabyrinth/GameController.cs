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
            IInput input, IGraphics graphics, int sizeX, int sizeY)
        {
            Logger.GetInstance().Log("INFO", $"Starting game. Grid: {sizeX}:{sizeY}. Language : {language}");
            var lang = new Language(language, language + "_dictionary.txt");
            ResetGameStatus(lang);
            _currentDictionary = new Dictionary(lang);
            _currentPlayer = new Player(new Point { X = -1, Y = 0 });
            _sizeX = sizeX;
            _sizeY = sizeY;
            _currentGrid = new LetterGrid(sizeX, sizeY, new SmartGridFiller(_currentDictionary));
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
            var letter = _currentGrid.ConsumeLetterAt(position);
            if (move != Move.Drop)
            {
                var currentWord = GameStatus.GetInstance().AddLetter(letter);
                var currentWordString = Dictionary.StringFromLetters(currentWord);
                if (_currentDictionary.AnyWordBeginsWith(currentWord))
                {
                    Logger.GetInstance().Log("INFO", $"Word exists that starts with: {currentWordString}");
                    if (_currentDictionary.WordFragmentExistsInPath(currentWord))
                    {
                        Logger.GetInstance().Log("INFO", $"Word fragment exists in path: {currentWordString}");
                        if (_currentDictionary.WordExistsInPath(currentWord))
                        {
                            Logger.GetInstance().Log("INFO", $"Found word in path: {currentWordString}");
                            GameStatus.GetInstance().ConsumeCurrentWord(true);
                        }
                    }
                    else
                    {
                        if (currentWord.Length > 2 && _currentDictionary.WordExists(currentWord))
                        {
                            Logger.GetInstance().Log("INFO", $"Word '{currentWordString}' is correct.");
                            GameStatus.GetInstance().ConsumeCurrentWord(true);
                        }
                    }
                }
                else
                {
                    Logger.GetInstance().Log("INFO", $"Word '{currentWordString}' is wrong. Removing points.");
                    GameStatus.GetInstance().ConsumeCurrentWord(false);
                }
            }
            else
            {
                Logger.GetInstance().Log("INFO", $"Dropping word.");
                GameStatus.GetInstance().ConsumeCurrentWord(false);
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
