namespace Parsers
{
    public interface IParser<T>
    {
        ParserResult<T> Parse(string source, string remainder);

        public static IParser<T> operator |(IParser<T> first, IParser<T> second)
            => new OrParser<T>(first, second);
    }
}