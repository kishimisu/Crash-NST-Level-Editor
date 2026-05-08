namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(CVscComponentData))]
    public class common_BonusRoundEndData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _StartEntity = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _AnimTarget = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _CollectibleToSpawn = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _CollectibleSpawnDelay;
        [FieldAttr(nst: 72, ctr: 64)] public string? _IdleAnim = null;
        [FieldAttr(nst: 80, ctr: 72)] public string? _TriggeredAnim_0x50 = null;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 96, ctr: 88)] public string? _TriggeredAnim_0x60 = null;
        [FieldAttr(nst: 104, ctr: 96)] public string? _TriggeredAnim_0x68 = null;
        [FieldAttr(nst: 112, ctr: 104)] public float _Float;
        [FieldAttr(nst: 116, ctr: 108)] public EZoneCollectibleType _E_Zone_Collectible_Type;
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Sound = new();
    }
}
