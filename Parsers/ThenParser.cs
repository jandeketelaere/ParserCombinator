namespace Parsers
{
    public class ThenParser<T, U> : IParser<U>
    {
        private readonly IParser<T> _inner;
        private readonly Func<T, IParser<U>> _continuation;

        public ThenParser(IParser<T> inner, Func<T, IParser<U>> continuation)
        {
            _inner = inner;
            _continuation = continuation;
        }

        public ParserResult<U> Parse(string source, string remainder)
        {
            var parseResult = _inner.Parse(source, remainder);
            var (result, value) = parseResult;

            if (result.IsFailure)
                return ParserResult<U>.Error(result.Source, result.Remainder, result.Expected);

            var nextParseResult = _continuation(value);
            return nextParseResult.Parse(result.Source, result.Remainder);
        }
    }
}