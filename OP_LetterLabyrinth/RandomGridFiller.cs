using System;
using System.Collections.Generic;
using System.Linq;

namespace OP_LetterLabyrinth
{
    public class RandomGridFiller : IGridFiller
    {
        protected Dictionary Dictionary;

        public RandomGridFiller(Dictionary dictionary)
        {
            Dictionary = dictionary;
        }

        private Letter GetLetterInFrequencyIndex(IEnumerable<Letter> letters, int index)
        {
            var sum = 0;
            foreach (var letter in letters)
            {
                sum += letter.GetFrequency();
                if (sum >= index)
                {
                    return letter;
                }
            }
            return letters.First();
        }

        protected List<List<Letter>> FillRandomLetters(int sizeX, int sizeY)
        {
            var letters = Dictionary.GetLetters();
            var orderedLetters = letters.OrderBy(l => l.GetFrequency());
            var totalFrequency = letters.Sum(l => l.GetFrequency());
            var random = new Random();
            var list = new List<List<Letter>>();
            for (var i = 0; i < sizeX; i++)
            {
                var rowList = new List<Letter>();
                for (var j = 0; j < sizeY; j++)
                {
                    rowList.Add(GetLetterInFrequencyIndex(orderedLetters, random.Next(totalFrequency)));
                }
                list.Add(rowList);
            }
            return list;
        }

        public virtual List<List<Letter>> GetLetters(int sizeX, int sizeY)
        {
            return FillRandomLetters(sizeX, sizeY);
        }
    }
}