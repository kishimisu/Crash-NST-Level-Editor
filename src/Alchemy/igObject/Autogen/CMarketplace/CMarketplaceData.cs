namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 168, align: 8)]
    public class CMarketplaceData : igObject
    {
        [FieldAttr(nst: 16, ctr: 12)] public uint _baseItemId = 100;
        [FieldAttr(nst: 20, ctr: 16)] public uint _baseProductId = 1000;
        [FieldAttr(nst: 24, ctr: 20)] public uint _baseCurrencyId = 10;
        [FieldAttr(nst: 28, ctr: 24)] public uint _baseSkuId = 2000;
        [FieldAttr(ctr: 32)] public string? _storeMenuName;
        [FieldAttr(ctr: 40)] public igHandleMetaField _checkmarkIcon = new();
        [FieldAttr(ctr: 48)] public igHandleMetaField _warningIcon = new();
        [FieldAttr(ctr: 56)] public EOctaneMarketplaceItemCategoryList? _bundlesOrder;
        [FieldAttr(ctr: 64)] public EOctaneMarketplaceItemCategoryListList? _categoryPriorities;
        [FieldAttr(ctr: 72)] public CMarketplaceItemShowcaseWeights? _itemShowcaseWeights;
        [FieldAttr(ctr: 80)] public CMarketplaceFeaturedSkuCalendar? _featuredItemsCalendar;
        [FieldAttr(nst: 32, ctr: 88)] public CMarketplaceItemHandleList? _marketplaceItems;
        [FieldAttr(nst: 40, ctr: 96)] public CMarketplaceCurrencyList? _marketplaceCurrencies;
        [FieldAttr(nst: 48, ctr: 104)] public CMarketplaceProductList? _marketplaceProducts;
        [FieldAttr(nst: 56, ctr: 112)] public CMarketplaceSkuList? _marketplaceSkus;
        [FieldAttr(nst: 64, ctr: 120)] public CMarketplaceExchangeSkuDataList? _marketplaceExchangeSkus;
        [FieldAttr(nst: 72)] public CMarketplaceLootBoxDataList? _marketplaceLootBoxData;
        [FieldAttr(nst: 80)] public CMarketplaceLootBoxRarityDataList? _marketplaceLootBoxRarityData;
        [FieldAttr(ctr: 128)] public CUnlockablePackageList? _packages;
        [FieldAttr(ctr: 136)] public CUnlockablePackageFirstPartyList? _firstPartyPackages;
        [FieldAttr(ctr: 144)] public float _defaultDriverShowcaseScale;
        [FieldAttr(ctr: 152)] public igStringFloatHashTable? _driverShowcaseScaleTable;
        [FieldAttr(ctr: 160)] public EOctaneMarketplaceItemCategoryNamesTable? _categoryNamesTable;
    }
}
