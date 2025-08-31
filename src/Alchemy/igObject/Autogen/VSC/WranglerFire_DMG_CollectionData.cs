namespace Alchemy
{
    // VSC object extracted from: WranglerFire_DMG_Collection_c.igz

    [ObjectAttr(128, metaType: typeof(CVscComponentData))]
    public class WranglerFire_DMG_CollectionData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Melee01DMG = new();
        [FieldAttr(48)] public igHandleMetaField _Melee02DMG = new();
        [FieldAttr(56)] public igHandleMetaField _Melee03DMG = new();
        [FieldAttr(64)] public igHandleMetaField _ChargeLongDMG = new();
        [FieldAttr(72)] public igHandleMetaField _ChargeEndDMGRed = new();
        [FieldAttr(80)] public igHandleMetaField _ChargeDOTDMG = new();
        [FieldAttr(88)] public igHandleMetaField _ChargeDOTRemovalDMG = new();
        [FieldAttr(96)] public igHandleMetaField _ChargeEndDMGWolf = new();
        [FieldAttr(104)] public igHandleMetaField _Melee01BDMG = new();
        [FieldAttr(112)] public igHandleMetaField _AxeDMG = new();
        [FieldAttr(120)] public igHandleMetaField _ChargeShortDMG = new();
    }
}
