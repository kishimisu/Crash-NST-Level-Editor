namespace Alchemy
{
    // VSC object extracted from: common_Collectible_Template_Spawned_c.igz

    [ObjectAttr(112, metaType: typeof(CVscComponentData))]
    public class common_Collectible_Template_SpawnedData : CVscComponentData
    {
        [FieldAttr(40)] public bool _CanSpinAway;
        [FieldAttr(48)] public igHandleMetaField _SpinAwaySound = new();
        [FieldAttr(56)] public igHandleMetaField _CollectSound = new();
        [FieldAttr(64)] public igHandleMetaField _CollectVFX = new();
        [FieldAttr(72)] public igHandleMetaField _SpinAwayVFX = new();
        [FieldAttr(80)] public igHandleMetaField _Game_Bool_Variable_0x50 = new();
        [FieldAttr(88)] public igHandleMetaField _Game_Bool_Variable_0x58 = new();
        [FieldAttr(96)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(104)] public bool _Bool;
    }
}
