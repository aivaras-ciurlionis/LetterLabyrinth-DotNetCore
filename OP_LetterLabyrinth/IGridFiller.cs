using System.Collections.Generic;

namespace OP_LetterLabyrinth
{
    public interface IGridFiller
    {
        List<List<Letter>> GetLetters(int sizeX, int sizeY);
    }
}