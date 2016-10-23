namespace OP_LetterLabyrinth
{
    public class Language
    {
        private readonly LanguageName _name;
        private readonly string _dictionaryLocation;

        public Language(LanguageName name, string dictionaryLocation)
        {
            _name = name;
            _dictionaryLocation = dictionaryLocation;
        }

        public string GetDictionaryLocation()
        {
            return _dictionaryLocation;
        }

        public string GetLanguageName()
        {
            return _name.ToString();
        }

    }
}