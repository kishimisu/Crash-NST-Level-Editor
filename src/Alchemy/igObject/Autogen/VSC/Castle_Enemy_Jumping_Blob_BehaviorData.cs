namespace Alchemy
{
    // VSC object extracted from: Castle_Enemy_Jumping_Blob_Behavior_c.igz

    [ObjectAttr(200, metaType: typeof(CVscComponentData))]
    public class Castle_Enemy_Jumping_Blob_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public bool _ActivateOnSpawn;
        [FieldAttr(41)] public bool _TrackPlayer;
        [FieldAttr(42)] public bool _SetStartingPostion;
        [FieldAttr(48)] public igHandleMetaField _TargetList = new();
        [FieldAttr(56)] public float _JumpHeight;
        [FieldAttr(60)] public float _JumpTime;
        [FieldAttr(64)] public float _PauseBetweenJumps;
        [FieldAttr(68)] public float _Range;
        [FieldAttr(72)] public int _StartingIndex;
        [FieldAttr(80)] public string? _Jump = null;
        [FieldAttr(88)] public string? _Idle = null;
        [FieldAttr(96)] public string? _Land = null;
        [FieldAttr(104)] public string? _Despawn = null;
        [FieldAttr(112)] public bool _Bool_0x70;
        [FieldAttr(120)] public string? _String_0x78 = null;
        [FieldAttr(128)] public igVec3fMetaField _Vec_3F = new();
        [FieldAttr(140)] public float _Float_0x8c;
        [FieldAttr(144)] public string? _String_0x90 = null;
        [FieldAttr(152)] public igHandleMetaField _Vfx_Effect_0x98 = new();
        [FieldAttr(160)] public igHandleMetaField _Vfx_Effect_0xa0 = new();
        [FieldAttr(168)] public igHandleMetaField _Debug_Update_Channel = new();
        [FieldAttr(176)] public float _Float_0xb0;
        [FieldAttr(180)] public float _FloatVariable_id_kxweq4ng_variable;
        [FieldAttr(184)] public bool _Bool_0xb8;
        [FieldAttr(188)] public float _Float_0xbc;
        [FieldAttr(192)] public bool _Bool_0xc0;
        [FieldAttr(193)] public bool _Bool_0xc1;
    }
}
