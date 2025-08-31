namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CVehicleModVfxComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CVehicleModeVfxDataListList? _primaryMods;
        [FieldAttr(32)] public CVehicleModeVfxDataListList? _secondaryMods;
        [FieldAttr(40)] public CVehicleModeVfxDataList? _superChargedMod;
    }
}
