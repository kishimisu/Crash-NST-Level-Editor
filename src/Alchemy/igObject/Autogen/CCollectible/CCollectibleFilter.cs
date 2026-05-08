namespace Alchemy
{
    [ObjectAttr(nst: 32, ctr: 32, align: 8)]
    public class CCollectibleFilter : igObject
    {
        [FieldAttr(nst: 16, ctr: 16)] public CCollectibleTypeList? _validCollectibleTypesList;
        [FieldAttr(nst: 24, ctr: 24)] public CCollectibleTypeList? _excludeCollectibleTypesList;
    }
}
