namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 48, align: 8)]
    public class CMarketplaceExchangeSkuData : igObject
    {
        [ObjectAttr(size: 2)]
        public class Bitfield : igBitFieldMetaField
        {
            [FieldAttr(offset: 0, size: 1)] public bool _enabled = true;
            [FieldAttr(offset: 1, size: 1)] public bool _coupon;
            [FieldAttr(offset: 2, size: 1)] public bool _consumable = false;
        }

        [FieldAttr(nst: 16, ctr: 12)] public uint _exchangeSkuID;
        [FieldAttr(nst: 24, ctr: 16)] public igHandleMetaField _product = new();
        [FieldAttr(nst: 32, ctr: 24)] public Bitfield _bitfield = new();
        [FieldAttr(nst: 40, ctr: 32)] public string? _platform = null;
        [FieldAttr(nst: 48, ctr: 40)] public igStringStringHashTable? _platformData;
    }
}
