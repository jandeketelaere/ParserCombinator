namespace Parsers
{
    public static class Dsl
    {
        public static IParser<char> Character(char character)
            => new CharacterParser(character);

        public static IParser<char> Whitespace
            => new CharacterParser(' ');

        public static IParser<char> LeftParenthesis
            => new CharacterParser('(');

        public static IParser<char> RightParenthesis
            => new CharacterParser(')');

        public static IParser<string> String(string text)
            => new StringParser(text);

        public static IParser<string> NaturalNumber(int length)
            => new NaturalNumberParser(length);
    }
}