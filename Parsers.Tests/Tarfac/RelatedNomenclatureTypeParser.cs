namespace Parsers.Tests.Tarfac
{
    public class RelatedNomenclatureTypeParser : IParser<RelatedNomenclatureType>
    {
        public ParserResult<RelatedNomenclatureType> Parse(string source, string remainder)
        {
            var parser = 
                Dsl.String("vervangen uitneembare onderprothese").Return(RelatedNomenclatureType.LowerDentureRebasing)
                | Dsl.String("vervangen uitneembare bovenprothese").Return(RelatedNomenclatureType.UpperDentureRebasing)
                | Dsl.String("bijplaatsen uitneembare onderprothese").Return(RelatedNomenclatureType.RemovableLowerProsthesis)
                | Dsl.String("bijplaatsen uitneembare bovenprothese").Return(RelatedNomenclatureType.RemovableUpperProsthesis);

            return parser.Parse(source, remainder);
        }
    }
}