namespace Parsers
{
    public class OrParser<T> : IParser<T>
    {
        private readonly IParser<T> _first;
        private readonly IParser<T> _second;

        public OrParser(IParser<T> first, IParser<T> second)
        {
            _first = first;
            _second = second;
        }

        public ParserResult<T> Parse(string source, string remainder)
        {
            var firstParseResult = _first.Parse(source, remainder);
            if (firstParseResult.Result.IsSuccessful)
                return firstParseResult;

            var secondParseResult = _second.Parse(source, remainder);
            if (secondParseResult.Result.IsSuccessful)
                return secondParseResult;

            return ParserResult<T>.Error(source, remainder, string.Join(", ", new[] { firstParseResult.Result.Expected, secondParseResult.Result.Expected }));
        }
    }
}