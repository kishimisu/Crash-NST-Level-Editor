namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CVehiclePersonalizationBoostItem : CVehiclePersonalizationBaseItem
    {
        [FieldAttr(64)] public igHandleMetaField _data = new();
        [FieldAttr(72)] public EVehiclePersonalizationBoost _boost = EVehiclePersonalizationBoost.eVPB_None;
    }
}
