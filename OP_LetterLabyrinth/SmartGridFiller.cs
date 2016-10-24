using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace OP_LetterLabyrinth
{
    public class SmartGridFiller : RandomGridFiller
    {
        private int _sizeX;
        private int _sizeY;
        private Random random = new Random();

        private bool GetPath(ref List<Point> usedPoints, Point lastPoint)
        {
            if (lastPoint.X == _sizeX - 1 || lastPoint.Y == _sizeY - 1)
            {
                usedPoints.Add(lastPoint);
                Logger.GetInstance().Log("INFO", $"Found labyrinth end: {lastPoint.X}:{lastPoint.Y}");
                return true;
            }
            if (lastPoint.X < 0 || lastPoint.Y < 0 || lastPoint.X >= _sizeX - 1 || lastPoint.Y >= _sizeY - 1 ||
                usedPoints.Any(p => p.X == lastPoint.X && p.Y == lastPoint.Y))
            {
                Logger.GetInstance().Log("INFO", $"Wrong point, going back: {lastPoint.X}:{lastPoint.Y}");
                return false;
            }
            usedPoints.Add(lastPoint);
            Logger.GetInstance().Log("INFO", $"Adding point to path: {lastPoint.X}:{lastPoint.Y}");
            var next = new Point { X = -1, Y = -1 };
            var thisResult = false;
            var moves = new List<Move> { Move.Down, Move.Left, Move.Right, Move.Up };
            var shuffled = moves.OrderBy(m => random.Next());
            foreach (var move in shuffled)
            {
                switch (move)
                {
                    case Move.Right: next = new Point { X = lastPoint.X + 1, Y = lastPoint.Y }; break;
                    case Move.Down: next = new Point { X = lastPoint.X, Y = lastPoint.Y + 1 }; break;
                    case Move.Left: next = new Point { X = lastPoint.X - 1, Y = lastPoint.Y }; break;
                    case Move.Up: next = new Point { X = lastPoint.X, Y = lastPoint.Y - 1 }; break;
                }
                thisResult = GetPath(ref usedPoints, next);
                if (thisResult) { break; }
            }
            if (thisResult) return true;
            usedPoints.RemoveAt(usedPoints.Count - 1);
            Logger.GetInstance().Log("INFO", $"Removing last point: {lastPoint.X}:{lastPoint.Y}");
            return false;
        }

        public SmartGridFiller(Dictionary dictionary) : base(dictionary)
        {
        }

        public override List<List<Letter>> GetLetters(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            var path = new List<Point>();
            Logger.GetInstance().Log("INFO", $"Computing path...");
            GetPath(ref path, new Point { X = 0, Y = 0 });
            Logger.GetInstance().Log("INFO", $"Path length: {path.Count}");
            var letters = FillRandomLetters(sizeX, sizeY);

            var words = WordsFactoryProducer.GetFactory(nameof(PathProviderFactory))
                          .GetPathWordsProvider(nameof(DictionaryPathProvider))
                          .GetPathWords(path.Count, Dictionary);

            var letterWords = new List<Letter[]>();
            var pointNumber = 0;
            foreach (var word in words)
            {
                var wordLetters = Dictionary.GetLettersOfWord(word);
                letterWords.Add(wordLetters);
                foreach (var letter in wordLetters)
                {
                    var point = path[pointNumber];
                    letters[point.X][point.Y] = letter;
                    pointNumber++;
                }
            }
            var shuffled = letterWords.OrderBy(w => random.Next());
            foreach (var word in shuffled)
            {
                Dictionary.AddPathWord(word);
            }
            return letters;
        }
    }
}