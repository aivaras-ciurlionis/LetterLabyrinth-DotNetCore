using System;

namespace OP_LetterLabyrinth {

    public abstract class LetterDecorator : ILetter
    {
        protected ILetter DecoratedLetter;

        public LetterDecorator (ILetter letter)
        {
          DecoratedLetter = letter;
        }

        public virtual int GetFrequency() 
        {
            return DecoratedLetter.GetFrequency();
        }

        public virtual string GetName()
        {
            return DecoratedLetter.GetName();
        }

        public virtual int GetPoints()
        {
            return DecoratedLetter.GetPoints();
        }

        public virtual ConsoleColor GetRenderColor()
        {
            return DecoratedLetter.GetRenderColor();
        }

        public virtual string GetRenderName()
        {
            return DecoratedLetter.GetRenderName();
        }
    }


}