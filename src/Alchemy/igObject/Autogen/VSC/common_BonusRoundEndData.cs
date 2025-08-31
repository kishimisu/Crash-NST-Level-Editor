namespace Alchemy
{
    // VSC object extracted from: common_BonusRoundEnd_c.igz

    [ObjectAttr(128, metaType: typeof(CVscComponentData))]
    public class common_BonusRoundEndData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _StartEntity = new();
        [FieldAttr(48)] public igHandleMetaField _AnimTarget = new();
        [FieldAttr(56)] public igHandleMetaField _CollectibleToSpawn = new();
        [FieldAttr(64)] public float _CollectibleSpawnDelay;
        [FieldAttr(72)] public string? _IdleAnim = null;
        [FieldAttr(80)] public string? _TriggeredAnim_0x50 = null;
        [FieldAttr(88)] public igHandleMetaField _Entity = new();
        [FieldAttr(96)] public string? _TriggeredAnim_0x60 = null;
        [FieldAttr(104)] public string? _TriggeredAnim_0x68 = null;
        [FieldAttr(112)] public float _Float;
        [FieldAttr(116)] public EZoneCollectibleType _E_Zone_Collectible_Type;
        [FieldAttr(120)] public igHandleMetaField _Sound = new();
    }
}
