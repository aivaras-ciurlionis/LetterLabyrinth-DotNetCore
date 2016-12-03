using System;

namespace OP_LetterLabyrinth
{
    public interface ILetter
    {
        int GetPoints();
        int GetFrequency();
        string GetName();
        ConsoleColor GetRenderColor();
        string GetRenderName();
        bool isNill();
    }
}