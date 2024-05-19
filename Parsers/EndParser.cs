namespace Parsers
{
    public class EndParser<T> : IParser<T>
    {
        private readonly IParser<T> _inner;

        public EndParser(IParser<T> inner)
        {
            _inner = inner;
        }

        public ParserResult<T> Parse(string source, string remainder)
        {
            var parseResult = _inner.Parse(source, remainder);
            var result = parseResult.Result;

            if (result.IsFailure)
                return parseResult;

            if (result.Remainder.Length == 0)
                return parseResult;

            return ParserResult<T>.Error(result.Source, result.Remainder, "EOL");
        }
    }
}