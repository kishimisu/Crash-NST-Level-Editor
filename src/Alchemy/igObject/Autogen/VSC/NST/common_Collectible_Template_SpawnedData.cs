namespace Alchemy
{
    [ObjectAttr(nst: 112, ctr: 104, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Collectible_Template_SpawnedData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _CanSpinAway;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _SpinAwaySound = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _CollectSound = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _CollectVFX = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _SpinAwayVFX = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Game_Bool_Variable_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Game_Bool_Variable_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 104, ctr: 96)] public bool _Bool;
    }
}
