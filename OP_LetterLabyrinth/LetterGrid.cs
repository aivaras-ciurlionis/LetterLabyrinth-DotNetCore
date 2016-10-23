/**
 * @(#) LetterGrid.cs
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OP_LetterLabyrinth
{
    public class LetterGrid
    {
        private int _sizeX;
        private int _sizeY;
        private List<List<Letter>> _letters = new List<List<Letter>>();

        public LetterGrid(int sizeX, int sizeY, IGridFiller filler)
        {
            Logger.GetInstance().Log("INFO", "Filling grid");
            var letters = filler.GetLetters(sizeX, sizeY);
            _letters.AddRange(letters.Select(l => l.ToList()));
            _sizeX = sizeX;
            _sizeY = sizeY;
        }

        public Letter ConsumeLetterAt(Point point)
        {
            var consumedLetter = _letters[point.X][point.Y];
            _letters[point.X][point.Y] = Letter.Empty();
            Logger.GetInstance().Log("INFO", $"Consuming letter {consumedLetter.GetName()} at {point.X}:{point.Y}");
            return consumedLetter;
        }

        public bool PointIsInGrid(Point point)
        {
            return point.X > -1 && point.Y > -1 && point.X < _sizeX && point.Y < _sizeY;
        }

        public override string ToString()
        {
            var matrix = new StringBuilder();
            foreach (var row in _letters)
            {
                foreach (var letter in row)
                {
                    matrix.Append(letter.GetName() + " ");
                }
                matrix.Append(Environment.NewLine);
            }
            return matrix.ToString();
        }


    }
}
