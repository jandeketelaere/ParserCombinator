namespace Parsers
{
    public class ParserResult<T>
    {
        public ParserResult Result { get; }
        public T Value { get; }

        private ParserResult(ParserResult result, T value)
        {
            Result = result;
            Value = value;
        }

        public static ParserResult<T> Ok(T value, string source, string remainder)
            => new ParserResult<T>(ParserResult.Ok(source, remainder), value);

        public static ParserResult<T> Error(string source, string remainder, string expected)
            => new ParserResult<T>(ParserResult.Error(source, remainder, expected), default);

        public void Deconstruct(out ParserResult result, out T value)
        {
            result = Result;
            value = Value;
        }
    }

    public class ParserResult
    {
        public bool IsSuccessful { get; }
        public bool IsFailure => !IsSuccessful;
        public string Source { get; }
        public string Remainder { get; }
        public string Expected { get; }

        private ParserResult(bool isSuccessful, string source, string remainder, string expected)
        {
            IsSuccessful = isSuccessful;
            Source = source;
            Remainder = remainder;
            Expected = expected;
        }

        public static ParserResult Ok(string source, string remainder)
            => new ParserResult(true, source, remainder, null);

        public static ParserResult Error(string source, string remainder, string expected)
            => new ParserResult(false, source, remainder, expected);
    }
}