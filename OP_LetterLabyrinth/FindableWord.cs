namespace OP_LetterLabyrinth
{
    public class FindableWord
    {
        private readonly string _word;
        private readonly int _points;
        private bool _found;

        public FindableWord(string word, int points, bool found)
        {
            _word = word;
            _points = points;
            _found = found;
        }

        public void MarkFound()
        {
            _found = true;
        }

        public string GetWord()
        {
            return _word;
        }

        public bool IsFound()
        {
            return _found;
        }

        public override string ToString()
        {
            return (_found ? "*" : "") + $"{_word.ToUpper()} ({_points})";
        }

        public string ToStringNegative()
        {
            return (_found? "*" : "") + $"{_word.ToUpper()} (-{_points})";
        }

}
}
