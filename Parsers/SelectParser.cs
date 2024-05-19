namespace Parsers
{
    public class SelectParser<T, U> : IParser<U>
    {
        private readonly IParser<T> _inner;
        private readonly Func<T, U> _selector;

        public SelectParser(IParser<T> inner, Func<T, U> selector)
        {
            _inner = inner;
            _selector = selector;
        }

        public ParserResult<U> Parse(string source, string remainder)
        {
            var parseResult = _inner.Parse(source, remainder);
            var (result, value) = parseResult;

            if (result.IsFailure)
                return ParserResult<U>.Error(result.Source, result.Remainder, result.Expected);

            var newValue = _selector(value);
            return ParserResult<U>.Ok(newValue, result.Source, result.Remainder);
        }
    }
}