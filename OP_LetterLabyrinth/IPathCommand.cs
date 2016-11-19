namespace OP_LetterLabyrinth
{
    public interface IPathCommand
    {
        string Execute();
        int UndoLength();
    }
}