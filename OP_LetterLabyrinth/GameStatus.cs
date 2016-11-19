using System;
using System.Collections.Generic;
using System.Linq;

namespace OP_LetterLabyrinth
{
    public class GameStatus
    {
        private static GameStatus _instance;
        private Language _currentLanguage;
        private int _points;
        private List<ILetter> _currentWord = new List<ILetter>();

        private GameStatus()
        {
            _currentWord = new List<ILetter>();
            _points = 0;
        }

        public static GameStatus GetInstance()
        {
            return _instance ?? (_instance = new GameStatus());
        }

        public int GetPoints()
        {
            return _points;
        }

        public int AddPoints(int points)
        {
            return _points += points;
        }

        public void AddLetter(ILetter letter)
        {
            _currentWord.Add(letter);
        }

        public ILetter[] ClearCurrentWord()
        {
            var word = _currentWord.ToArray();
            _currentWord.Clear();
            return word;
        }

        private int GetWordPoints()
        {
            return _currentWord.Sum(l => l.GetPoints());
        }

        private string GetWordLetterPoints()
        {
            return _currentWord.Aggregate("", (a, b) => $"{a}{b.GetPoints()} ");
        }

        public void AddPointsForCurrentWord(bool positivePoints)
        {
            var wordPoints = GetWordPoints();
            AddPoints(positivePoints ? wordPoints : -wordPoints);
        }

        public void ConsumeCurrentWord(bool positivePoints)
        {
            AddPointsForCurrentWord(positivePoints);
            ClearCurrentWord();
        }

        public void ResetPoints()
        {
            _points = 0;
        }

        public ILetter[] GetCurrentWord()
        {
            return _currentWord.ToArray();
        }

        public override string ToString()
        {
            var currentWord = _currentWord.Aggregate("", (s, letter) => s += letter.GetName().ToUpper());
            var languageName = _currentLanguage.GetLanguageName().ToUpper();
            return $"Current language: {languageName} {Environment.NewLine}" +
                   $"Current word: {currentWord} ({GetWordLetterPoints()}) {Environment.NewLine} " +
                   $"Points: {_points} {Environment.NewLine}";
        }

        public void SetLanguage(Language language)
        {
            _currentLanguage = language;
        }

    }
}


