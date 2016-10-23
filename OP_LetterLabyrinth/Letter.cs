/**
 * @(#) Letter.cs
 */

namespace OP_LetterLabyrinth
{
    public class Letter
    {
        private readonly string _letterName;
        private readonly int _letterPoints;
        private readonly int _frequency;

        public Letter( string letterName, int letterPoints, int frequency)
        {
            _letterName = letterName;
            _letterPoints = letterPoints;
            _frequency = frequency;
        }
	
        public int GetPoints(  )
        {
            return _letterPoints;
        }

        public int GetFrequency()
        {
            return _frequency;
        }

        public string GetName(  )
        {
            return _letterName;
        }
	
        public static Letter Empty(  )
        {
            return new Letter("*", 0, 0);
        }

        public static Letter Path()
        {
            return new Letter("X", 0, 0);
        }


    }
}

