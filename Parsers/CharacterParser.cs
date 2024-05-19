namespace Parsers
{
    public class CharacterParser : IParser<char>
    {
        private readonly char _character;

        public CharacterParser(char character)
        {
            _character = character;
        }

        public ParserResult<char> Parse(string source, string remainder)
        {
            if (remainder.ElementAtOrDefault(0) == _character)
                return ParserResult<char>.Ok(_character, source, remainder.Substring(1));

            return ParserResult<char>.Error(source, remainder, _character.ToString());
        }
    }
}