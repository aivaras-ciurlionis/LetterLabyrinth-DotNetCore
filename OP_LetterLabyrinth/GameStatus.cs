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

        private List<Letter> _currentWord = new List<Letter>();

        private GameStatus()
        {
            _currentWord = new List<Letter>();
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

        public Letter[] AddLetter(Letter letter)
        {
            _currentWord.Add(letter);
            return _currentWord.ToArray();
        }

        public Letter[] ClearCurrentWord()
        {
            var word = _currentWord.ToArray();
            _currentWord.Clear();
            return word;
        }

        public void ConsumeCurrentWord(bool positivePoints)
        {
            var consumedWord = ClearCurrentWord();
            var wordPoints = consumedWord.Sum(l => l.GetPoints());
            AddPoints(positivePoints ? wordPoints : -wordPoints);
        }

        public void ResetPoints()
        {
            _points = 0;
        }

        public override string ToString()
        {
            var currentWord = _currentWord.Aggregate("", (s, letter) => s+=letter.GetName().ToUpper());
            var languageName = _currentLanguage.GetLanguageName().ToUpper();
            return $"Current language: {languageName} {Environment.NewLine}" +
                   $"Current word: {currentWord} {Environment.NewLine} " +
                   $"Points: {_points} {Environment.NewLine}";
        }

        public void SetLanguage(Language language)
        {
            _currentLanguage = language;
        }

    }
}


