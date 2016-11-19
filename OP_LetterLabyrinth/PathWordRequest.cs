namespace OP_LetterLabyrinth
{
    public class PathWordRequest
    {
        private readonly string _word;
        private readonly Dictionary _dictionary;

        public PathWordRequest(string word, Dictionary dictionary)
        {
            _word = word;
            _dictionary = dictionary;
        }

        public string GetBindedWord()
        {
            return _word;
        }

        public string GetRandomWordOfGivenLength()
        {
            var length = int.Parse(_word);
            return _dictionary.GetAnyWordOfLength(length);
        }

    }
}