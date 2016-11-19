using System;

namespace OP_LetterLabyrinth
{

    public class SecretLetterDecorator : LetterDecorator
    {
        public SecretLetterDecorator(ILetter letter) : base(letter)
        {
        }

        public override int GetPoints()
        {
            return 100;
        }

        public override ConsoleColor GetRenderColor()
        {
            return ConsoleColor.Blue;
        }

        public override string GetRenderName()
        {
            return "?";
        }
    }
}