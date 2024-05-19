namespace Parsers.Tests.Tarfac
{
    public class RequiresRelatedNomenclature : Requirement
    {
        public RelatedNomenclatureType RelatedNomenclatureType { get; set; }
        public IList<NomenclatureIdentification> Nomenclatures { get; set; }
    }
}