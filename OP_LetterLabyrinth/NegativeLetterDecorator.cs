using System;

namespace OP_LetterLabyrinth
{

    public class NegativeLetterDecorator : LetterDecorator
    {

        public NegativeLetterDecorator(ILetter letter) : base(letter)
        {
        }

        public override int GetPoints()
        {
            return - 4 * DecoratedLetter.GetPoints();
        }

        public override ConsoleColor GetRenderColor()
        {
            return ConsoleColor.Red;
        }

        public override string GetRenderName()
        {
            return DecoratedLetter.GetName();
        }

    }

}