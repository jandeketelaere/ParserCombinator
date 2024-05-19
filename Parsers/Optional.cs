namespace Parsers
{
    public class Optional<T>
    {
        public bool HasValue { get; }
        public T Value { get; }

        private Optional(bool hasValue, T value)
        {
            HasValue = hasValue;
            Value = value;
        }

        public static Optional<T> Some(T value)
            => new Optional<T>(true, value);

        public static Optional<T> None()
            => new Optional<T>(false, default);
    }
}