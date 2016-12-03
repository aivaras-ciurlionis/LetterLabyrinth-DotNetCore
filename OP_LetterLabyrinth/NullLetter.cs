using System;

namespace OP_LetterLabyrinth
{
    public class NullLetter : ILetter
    {
        public int GetFrequency()
        {
            return 1;
        }

        public string GetName()
        {
            return "^";
        }

        public int GetPoints()
        {
            return 0;
        }

        public ConsoleColor GetRenderColor()
        {
            return ConsoleColor.Yellow;
        }

        public string GetRenderName()
        {
            return "^";
        }

        public bool isNill()
        {
            return true;
        }
    }

}