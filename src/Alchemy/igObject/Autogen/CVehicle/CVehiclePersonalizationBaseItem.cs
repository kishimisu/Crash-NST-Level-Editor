namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CVehiclePersonalizationBaseItem : CMarketplaceItem
    {
        [FieldAttr(40)] public string? _dataPackage = null;
        [FieldAttr(48)] public igHandleMetaField _iconGuiMaterial = new();
        [FieldAttr(56)] public int _itemIndex = -1;
    }
}
