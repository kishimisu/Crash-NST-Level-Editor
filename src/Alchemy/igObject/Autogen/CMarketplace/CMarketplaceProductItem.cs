namespace Alchemy
{
    [ObjectAttr(nst: 32, ctr: 32, align: 8)]
    public class CMarketplaceProductItem : igObject
    {
        [FieldAttr(nst: 16, ctr: 16)] public igHandleMetaField _item = new();
        [FieldAttr(nst: 24, ctr: 24)] public uint _quantity;
    }
}
