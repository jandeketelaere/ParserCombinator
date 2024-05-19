namespace Parsers.Tests.Tarfac
{
    public class NomenclatureIdentificationParser : IParser<NomenclatureIdentification>
    {
        public ParserResult<NomenclatureIdentification> Parse(string source, string remainder)
        {
            var parser = from code in TarfacDsl.NomenclatureCode
                         from type in Dsl.Whitespace.Then(_ => TarfacDsl.NomenclatureType).Optional()
                         select new NomenclatureIdentification { Code = code, Type = type.HasValue ? type.Value : NomenclatureType.Riziv };

            return parser.Parse(source, remainder);
        }
    }
}