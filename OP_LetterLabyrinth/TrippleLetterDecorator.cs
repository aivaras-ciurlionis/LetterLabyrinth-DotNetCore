using System;

namespace OP_LetterLabyrinth
{

    public class TrippleLetterDecorator : LetterDecorator
    {

        public TrippleLetterDecorator(ILetter letter) : base(letter)
        {
        }

        public override int GetPoints()
        {
            return DecoratedLetter.GetPoints() * 3;
        }

        public override ConsoleColor GetRenderColor()
        {
            return ConsoleColor.Green;
        }

        public override string GetRenderName()
        {
            return DecoratedLetter.GetName();
        }

    }

}