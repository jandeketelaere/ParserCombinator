namespace Parsers.Tests.Tarfac
{
    public class NomenclatureCodeParser : IParser<string>
    {
        public ParserResult<string> Parse(string source, string remainder)
        {
            var parser = Dsl.NaturalNumber(6);

            return parser.Parse(source, remainder);
        }
    }
}