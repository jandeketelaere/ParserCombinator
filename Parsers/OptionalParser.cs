namespace Parsers
{
    public class OptionalParser<T> : IParser<Optional<T>>
    {
        private readonly IParser<T> _inner;

        public OptionalParser(IParser<T> inner)
        {
            _inner = inner;
        }

        public ParserResult<Optional<T>> Parse(string source, string remainder)
        {
            var parseResult = _inner.Parse(source, remainder);
            var (result, value) = parseResult;

            if (result.IsFailure)
            {
                if (remainder != result.Remainder) //only fail when partially parsed
                    return ParserResult<Optional<T>>.Error(result.Source, result.Remainder, result.Expected);

                return ParserResult<Optional<T>>.Ok(Optional<T>.None(), source, remainder);
            }

            return ParserResult<Optional<T>>.Ok(Optional<T>.Some(value), result.Source, result.Remainder);
        }
    }
}