namespace Parsers.Tests.Tarfac
{
    public class TarfacExample
    {
        [Fact]
        public void RequiresRelatedNomenclatureTest()
        {
            var dsl = "vereist betrekkelijk nummer vervangen uitneembare onderprothese uit 123456 hallo";

            var parser = from vereist in Dsl.String("vereist")
                         from w1 in Dsl.Whitespace
                         from betrekkelijk in Dsl.String("betrekkelijk")
                         from w2 in Dsl.Whitespace
                         from nummer in Dsl.String("nummer")
                         from w3 in Dsl.Whitespace
                         from relatedNomenclatureType in TarfacDsl.RelatedNomenclatureType
                         from uit in Dsl.String(" uit ")
                         from nomenclatureIdentification in TarfacDsl.NomenclatureIdentification
                         from w4 in Dsl.Whitespace
                         from hallo in Dsl.String("hallo")
                         .End()
                         select new RequiresRelatedNomenclature
                         {
                             RelatedNomenclatureType = relatedNomenclatureType,
                             Nomenclatures = new[] { nomenclatureIdentification }
                         } as Requirement;

            var (result, value) = parser.Parse(dsl);
        }
    }

    public static class TarfacDsl
    {
        public static IParser<RelatedNomenclatureType> RelatedNomenclatureType
            => new RelatedNomenclatureTypeParser();

        public static IParser<string> NomenclatureCode
            => new NomenclatureCodeParser();

        public static IParser<NomenclatureType> NomenclatureType
            => new NomenclatureTypeParser();

        public static IParser<NomenclatureIdentification> NomenclatureIdentification
            => new NomenclatureIdentificationParser();
    }
}