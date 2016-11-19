using System.Collections.Generic;
using System.Linq;

namespace OP_LetterLabyrinth
{
    public class PathCommandInvoker
    {
        private List<IPathCommand> _commands = new List<IPathCommand>();

        public void TakeCommand(IPathCommand command)
        {
            _commands.Add(command);
        }

        public int Undo()
        {
            var lastCommand = _commands.Last();
            _commands.Remove(lastCommand);
            return lastCommand.UndoLength();
        }

        public IEnumerable<string> GetWords()
        {
            return _commands.Select(c => c.Execute());
        }

    }
}