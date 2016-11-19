using System;
using System.Collections.Generic;
using System.Linq;

namespace OP_LetterLabyrinth
{
    public class RandomGridFiller : IGridFiller
    {
        Random random = new Random();

        protected Dictionary Dictionary;

        public RandomGridFiller(Dictionary dictionary)
        {
            Dictionary = dictionary;
        }

        private ILetter GetDecoratedLetter(ILetter letter)
        {
            var rnd = random.Next(100);
            if (rnd < 21)
            {
                letter = new NegativeLetterDecorator(letter);
            }
            if (rnd < 14)
            {
                letter = new TrippleLetterDecorator(letter);
            }
            if (rnd < 7)
            {
                letter = new SecretLetterDecorator(letter);
            }
            return letter;
        }

        private ILetter GetLetterInFrequencyIndex(IEnumerable<ILetter> letters, int index)
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

        protected List<List<ILetter>> FillRandomLetters(int sizeX, int sizeY)
        {
            var letters = Dictionary.GetLetters();
            var orderedLetters = letters.OrderBy(l => l.GetFrequency());
            var totalFrequency = letters.Sum(l => l.GetFrequency());

            var list = new List<List<ILetter>>();
            for (var i = 0; i < sizeX; i++)
            {
                var rowList = new List<ILetter>();
                for (var j = 0; j < sizeY; j++)
                {
                    var letter = GetLetterInFrequencyIndex(orderedLetters, random.Next(totalFrequency));
                    rowList.Add(GetDecoratedLetter(letter));
                }
                list.Add(rowList);
            }
            return list;
        }

        public virtual List<List<ILetter>> GetLetters(int sizeX, int sizeY)
        {
            return FillRandomLetters(sizeX, sizeY);
        }
    }
}