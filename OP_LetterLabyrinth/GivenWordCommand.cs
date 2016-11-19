using System;

namespace OP_LetterLabyrinth
{
    public class GivenWordCommand : IPathCommand
    {
        private readonly PathWordRequest _pathWord;

        public GivenWordCommand(PathWordRequest pathWord)
        {
            _pathWord = pathWord;
        }

        public string Execute()
        {
            return _pathWord.GetBindedWord();
        }

        public int UndoLength()
        {
            return _pathWord.GetBindedWord().Length;
        }
    }
}