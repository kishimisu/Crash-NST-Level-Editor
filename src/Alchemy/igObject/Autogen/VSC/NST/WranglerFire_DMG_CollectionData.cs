namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(CVscComponentData))]
    public class WranglerFire_DMG_CollectionData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Melee01DMG = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Melee02DMG = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Melee03DMG = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _ChargeLongDMG = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _ChargeEndDMGRed = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _ChargeDOTDMG = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _ChargeDOTRemovalDMG = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _ChargeEndDMGWolf = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Melee01BDMG = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _AxeDMG = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _ChargeShortDMG = new();
    }
}
