namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CVehiclePersonalizationBaseItemList : igObjectList<CVehiclePersonalizationBaseItem>
    {
        [FieldAttr(40)] public CVehiclePersonalizationBaseSharedData? _sharedData;
    }
}
