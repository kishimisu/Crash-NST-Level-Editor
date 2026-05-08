namespace Alchemy
{
    [ObjectAttr(nst: 40, ctr: 136, align: 8)]
    public class CMarketplaceSku : igObject
    {
        [FieldAttr(nst: 16, ctr: 12)] public uint _id;
        [FieldAttr(ctr: 16)] public EOctaneMarketplaceItemCategory _itemCategory;
        [FieldAttr(nst: 24, ctr: 24)] public igHandleMetaField _product = new();
        [FieldAttr(nst: 32)] public CMarketplaceSkuPriceList? _priceList;
        [FieldAttr(ctr: 32)] public igHandleMetaField _currency = new();
        [FieldAttr(ctr: 40)] public uint _price;
        [FieldAttr(ctr: 44)] public bool _couponEnabled;
        [FieldAttr(ctr: 48)] public uint _maxQuantity;
        [FieldAttr(ctr: 52)] public bool _isReserve;
        [FieldAttr(ctr: 56)] public float _displayedDiscount;
        [FieldAttr(ctr: 60)] public igTimeOfDayMetaField _saleStart = new();
        [FieldAttr(ctr: 88)] public igTimeOfDayMetaField _saleEnd = new();
        [FieldAttr(ctr: 120)] public CKartCustomizationPreset? _showcasePreset;
        [FieldAttr(ctr: 128)] public igHandleMetaField _streamingIcon = new();
    }
}
