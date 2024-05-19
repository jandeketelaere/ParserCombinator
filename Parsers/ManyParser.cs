namespace Parsers
{
    public class ManyParser<T> : IParser<IList<T>>
    {
        private readonly IParser<T> _inner;

        public ManyParser(IParser<T> inner)
        {
            _inner = inner;
        }

        public ParserResult<IList<T>> Parse(string source, string remainder)
        {
            var parseResult = _inner.Parse(source, remainder);
            var (result, value) = parseResult;

            if (result.IsFailure)
                return ParserResult<IList<T>>.Error(result.Source, result.Remainder, result.Expected);

            return ParseLoop(new[] { value }, result.Source, result.Remainder);
        }

        private ParserResult<IList<T>> ParseLoop(IList<T> previousValues, string source, string remainder)
        {
            var parseResult = _inner.Parse(source, remainder);
            var (result, value) = parseResult;

            if (result.IsFailure)
            {
                if (remainder != result.Remainder) //only fail when partially parsed
                    return ParserResult<IList<T>>.Error(result.Source, result.Remainder, result.Expected);

                return ParserResult<IList<T>>.Ok(previousValues, result.Source, result.Remainder);
            }

            var newValues = previousValues.Append(value).ToList();

            return ParseLoop(newValues, result.Source, result.Remainder);
        }
    }
}