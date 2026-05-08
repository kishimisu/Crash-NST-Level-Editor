namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 96, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_PlayerBounceReactionData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _HurtPlayerWhileFlipped;
        [FieldAttr(nst: 41, ctr: 33)] public bool _HurtPlayerAfterFlipped;
        [FieldAttr(nst: 44, ctr: 36)] public float _FlippedTimer;
        [FieldAttr(nst: 48, ctr: 40)] public string? _BounceRecover = null;
        [FieldAttr(nst: 56, ctr: 48)] public string? _BounceInitial = null;
        [FieldAttr(nst: 64, ctr: 56)] public string? _BounceRecoverTell = null;
        [FieldAttr(nst: 72, ctr: 64)] public string? _JumpBounce = null;
        [FieldAttr(nst: 80, ctr: 72)] public string? _BounceIdle = null;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0x60 = new();
    }
}
