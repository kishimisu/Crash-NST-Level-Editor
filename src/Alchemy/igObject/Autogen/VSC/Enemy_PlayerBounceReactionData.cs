namespace Alchemy
{
    // VSC object extracted from: Enemy_PlayerBounceReaction_c.igz

    [ObjectAttr(104, metaType: typeof(CVscComponentData))]
    public class Enemy_PlayerBounceReactionData : CVscComponentData
    {
        [FieldAttr(40)] public bool _HurtPlayerWhileFlipped;
        [FieldAttr(41)] public bool _HurtPlayerAfterFlipped;
        [FieldAttr(44)] public float _FlippedTimer;
        [FieldAttr(48)] public string? _BounceRecover = null;
        [FieldAttr(56)] public string? _BounceInitial = null;
        [FieldAttr(64)] public string? _BounceRecoverTell = null;
        [FieldAttr(72)] public string? _JumpBounce = null;
        [FieldAttr(80)] public string? _BounceIdle = null;
        [FieldAttr(88)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0x58 = new();
        [FieldAttr(96)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0x60 = new();
    }
}
