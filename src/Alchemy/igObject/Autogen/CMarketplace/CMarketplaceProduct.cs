namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 48, align: 8)]
    public class CMarketplaceProduct : igObject
    {
        [ObjectAttr(size: 4)]
        public class Bitfield : igBitFieldMetaField
        {
            [FieldAttr(offset: 0, size: 14)] public uint _id;
            [FieldAttr(offset: 14, size: 8)] public int _rarity = 255;
        }

        [FieldAttr(nst: 16, ctr: 12)] public Bitfield _bitfield = new();
        [FieldAttr(nst: 24, ctr: 16)] public string? _name = null;
        [FieldAttr(nst: 32, ctr: 24)] public string? _description = null;
        [FieldAttr(nst: 40, ctr: 32)] public CMarketplaceProductItemList? _items;
        [FieldAttr(ctr: 40)] public CMarketplaceProductCurrencyList? _currencies;
    }
}
