namespace Parsers
{
    public class NaturalNumberParser : IParser<string>
    {
        private readonly int _length;

        public NaturalNumberParser(int length)
        {
            _length = length;
        }

        public ParserResult<string> Parse(string source, string remainder)
        {
            if (remainder == null)
                return ParserResult<string>.Error(source, remainder, "Number(s)");

            for (int i = 0; i < _length; i++)
            {
                var character = remainder.ElementAtOrDefault(i);
                if (character >= '0' && character <= '9')
                    continue;

                return ParserResult<string>.Error(source, remainder, "Number(s)");
            }

            var value = remainder.Substring(0, _length);
            var newRemainder = remainder.Substring(_length);

            return ParserResult<string>.Ok(value, source, newRemainder);
        }
    }
}