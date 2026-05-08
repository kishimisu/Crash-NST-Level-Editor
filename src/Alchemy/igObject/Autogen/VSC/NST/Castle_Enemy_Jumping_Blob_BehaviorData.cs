namespace Alchemy
{
    [ObjectAttr(nst: 200, ctr: 192, align: 4, metaType: typeof(CVscComponentData))]
    public class Castle_Enemy_Jumping_Blob_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _ActivateOnSpawn;
        [FieldAttr(nst: 41, ctr: 33)] public bool _TrackPlayer;
        [FieldAttr(nst: 42, ctr: 34)] public bool _SetStartingPostion;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _TargetList = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _JumpHeight;
        [FieldAttr(nst: 60, ctr: 52)] public float _JumpTime;
        [FieldAttr(nst: 64, ctr: 56)] public float _PauseBetweenJumps;
        [FieldAttr(nst: 68, ctr: 60)] public float _Range;
        [FieldAttr(nst: 72, ctr: 64)] public int _StartingIndex;
        [FieldAttr(nst: 80, ctr: 72)] public string? _Jump = null;
        [FieldAttr(nst: 88, ctr: 80)] public string? _Idle = null;
        [FieldAttr(nst: 96, ctr: 88)] public string? _Land = null;
        [FieldAttr(nst: 104, ctr: 96)] public string? _Despawn = null;
        [FieldAttr(nst: 112, ctr: 104)] public bool _Bool_0x70;
        [FieldAttr(nst: 120, ctr: 112)] public string? _String_0x78 = null;
        [FieldAttr(nst: 128, ctr: 120)] public igVec3fMetaField _Vec_3F = new();
        [FieldAttr(nst: 140, ctr: 132)] public float _Float_0x8c;
        [FieldAttr(nst: 144, ctr: 136)] public string? _String_0x90 = null;
        [FieldAttr(nst: 152, ctr: 144)] public igHandleMetaField _Vfx_Effect_0x98 = new();
        [FieldAttr(nst: 160, ctr: 152)] public igHandleMetaField _Vfx_Effect_0xa0 = new();
        [FieldAttr(nst: 168, ctr: 160)] public igHandleMetaField _Debug_Update_Channel = new();
        [FieldAttr(nst: 176, ctr: 168)] public float _Float_0xb0;
        [FieldAttr(nst: 180, ctr: 172)] public float _FloatVariable_id_kxweq4ng_variable;
        [FieldAttr(nst: 184, ctr: 176)] public bool _Bool_0xb8;
        [FieldAttr(nst: 188, ctr: 180)] public float _Float_0xbc;
        [FieldAttr(nst: 192, ctr: 184)] public bool _Bool_0xc0;
        [FieldAttr(nst: 193, ctr: 185)] public bool _Bool_0xc1;
    }
}
