namespace Parsers
{
    public class StringParser : IParser<string>
    {
        private readonly string _text;

        public StringParser(string text)
        {
            _text = text;
        }

        public ParserResult<string> Parse(string source, string remainder)
        {
            if (remainder == null || !remainder.StartsWith(_text))
                return ParserResult<string>.Error(source, remainder, _text);

            return ParserResult<string>.Ok(_text, source, remainder.Substring(_text.Length));
        }
    }
}