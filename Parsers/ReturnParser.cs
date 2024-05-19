namespace Parsers
{
    public class ReturnParser<T, U> : IParser<U>
    {
        private readonly IParser<T> _inner;
        private readonly U _value;

        public ReturnParser(IParser<T> inner, U value)
        {
            _inner = inner;
            _value = value;    
        }

        public ParserResult<U> Parse(string source, string remainder)
        {
            var parseResult = _inner.Parse(source, remainder);
            var result = parseResult.Result;

            if (result.IsFailure)
                return ParserResult<U>.Error(result.Source, result.Remainder, result.Expected);

            return ParserResult<U>.Ok(_value, result.Source, result.Remainder);
        }
    }
}