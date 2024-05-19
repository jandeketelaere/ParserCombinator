namespace Parsers.Tests.Tarfac
{
    public class NomenclatureTypeParser : IParser<NomenclatureType>
    {
        public ParserResult<NomenclatureType> Parse(string source, string remainder)
        {
            var parser = from _ in Dsl.LeftParenthesis
                         from nomenclatureType in Dsl.String("riziv").Return(NomenclatureType.Riziv)
                                    | Dsl.String("ziekenhuis").Return(NomenclatureType.Hospital)
                                    | Dsl.String("apotheek").Return(NomenclatureType.Pharmacy)
                         from __ in Dsl.RightParenthesis
                         select nomenclatureType;

            return parser.Parse(source, remainder);
        }
    }
}