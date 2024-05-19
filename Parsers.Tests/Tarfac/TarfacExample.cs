namespace Parsers.Tests.Tarfac
{
    public class TarfacExample
    {
        [Fact]
        public void RequiresRelatedNomenclatureTest()
        {
            var dsl = "vereist betrekkelijk nummer vervangen uitneembare onderprothese uit 999999 (riziv) 12345 (ziekenhuis) 987654";

            var parser = from vereist in Dsl.String("vereist")
                         from _ in Dsl.Whitespace
                         from betrekkelijk in Dsl.String("betrekkelijk")
                         from __ in Dsl.Whitespace
                         from nummer in Dsl.String("nummer")
                         from ___ in Dsl.Whitespace
                         from relatedNomenclatureType in TarfacDsl.RelatedNomenclatureType
                         from ____ in Dsl.Whitespace
                         from uit in Dsl.String("uit")
                         from nomenclatures in Dsl.Whitespace.Then(_ => TarfacDsl.NomenclatureIdentification).Many()
                         .End()
                         select new RequiresRelatedNomenclature
                         {
                             RelatedNomenclatureType = relatedNomenclatureType,
                             Nomenclatures = nomenclatures
                         } as Requirement;

            var (result, value) = parser.Parse(dsl);

            var errorMessage = result.GetErrorMessage();
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