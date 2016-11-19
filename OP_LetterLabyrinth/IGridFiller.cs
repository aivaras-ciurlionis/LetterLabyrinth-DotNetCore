using System.Collections.Generic;

namespace OP_LetterLabyrinth
{
    public interface IGridFiller
    {
        List<List<ILetter>> GetLetters(int sizeX, int sizeY);
    }
}