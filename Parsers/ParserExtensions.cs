namespace Parsers
{
    public static class ParserExtensions
    {
        public static ParserResult<T> Parse<T>(this IParser<T> parser, string source)
            => parser.Parse(source, source);

        public static IParser<T> End<T>(this IParser<T> parser)
            => new EndParser<T>(parser);

        public static IParser<T> Or<T>(this IParser<T> first, IParser<T> second)
            => new OrParser<T>(first, second);

        public static IParser<Optional<T>> Optional<T>(this IParser<T> parser)
            => new OptionalParser<T>(parser);

        public static IParser<U> Then<T, U>(this IParser<T> parser, Func<T, IParser<U>> continuation)
            => new ThenParser<T, U>(parser, continuation);

        public static IParser<IList<T>> Many<T>(this IParser<T> parser)
            => new ManyParser<T>(parser);

        public static IParser<U> Select<T, U>(this IParser<T> parser, Func<T, U> selector)
            => new SelectParser<T, U>(parser, selector);

        public static IParser<U> Return<T, U>(this IParser<T> parser, U value)
            => new ReturnParser<T, U>(parser, value);

        public static IParser<V> SelectMany<T, U, V>(this IParser<T> parser, Func<T, IParser<U>> continuation, Func<T, U, V> selector)
            => parser.Then(t => continuation(t).Select(u => selector(t, u)));
    }
}