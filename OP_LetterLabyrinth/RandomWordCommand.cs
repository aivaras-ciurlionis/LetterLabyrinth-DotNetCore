using System;

namespace OP_LetterLabyrinth
{
    public class RandomWordCommand : IPathCommand
    {
        private readonly PathWordRequest _pathWord;

        public RandomWordCommand(PathWordRequest pathWord)
        {
            _pathWord = pathWord;
        }
        public string Execute()
        {
            return _pathWord.GetRandomWordOfGivenLength();
        }

        public int UndoLength()
        {
            return int.Parse(_pathWord.GetBindedWord());
        }
    }
}
