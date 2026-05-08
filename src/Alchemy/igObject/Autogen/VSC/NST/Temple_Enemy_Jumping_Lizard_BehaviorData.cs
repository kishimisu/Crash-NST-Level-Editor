namespace Alchemy
{
    [ObjectAttr(nst: 176, ctr: 168, align: 4, metaType: typeof(CVscComponentData))]
    public class Temple_Enemy_Jumping_Lizard_BehaviorData : CVscComponentData
    {
        public enum EStartingDirection
        {
            CountUp = 0,
            CountDown = 1,
        }

        [FieldAttr(nst: 40, ctr: 32)] public bool _TrackPlayer;
        [FieldAttr(nst: 41, ctr: 33)] public bool _SetStartingPostion;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _TargetList = new();
        [FieldAttr(nst: 56, ctr: 48)] public EStartingDirection _StartingDirection;
        [FieldAttr(nst: 60, ctr: 52)] public float _JumpHeight;
        [FieldAttr(nst: 64, ctr: 56)] public float _JumpDuration;
        [FieldAttr(nst: 68, ctr: 60)] public float _PauseBetweenJumps;
        [FieldAttr(nst: 72, ctr: 64)] public int _StartingIndex;
        [FieldAttr(nst: 80, ctr: 72)] public string? _Jump_0x50 = null;
        [FieldAttr(nst: 88, ctr: 80)] public string? _Idle = null;
        [FieldAttr(nst: 96, ctr: 88)] public string? _Land = null;
        [FieldAttr(nst: 104, ctr: 96)] public float _Float_0x68;
        [FieldAttr(nst: 108, ctr: 100)] public float _Float_0x6c;
        [FieldAttr(nst: 112, ctr: 104)] public string? _String_0x70 = null;
        [FieldAttr(nst: 120, ctr: 112)] public float _Float_0x78;
        [FieldAttr(nst: 124, ctr: 116)] public float _Float_0x7c;
        [FieldAttr(nst: 128, ctr: 120)] public string? _Jump_0x80 = null;
        [FieldAttr(nst: 136, ctr: 128)] public float _Range;
        [FieldAttr(nst: 140, ctr: 132)] public bool _Bool_0x8c;
        [FieldAttr(nst: 144, ctr: 136)] public string? _String_0x90 = null;
        [FieldAttr(nst: 152, ctr: 144)] public float _Float_0x98;
        [FieldAttr(nst: 156, ctr: 148)] public bool _Bool_0x9c;
        [FieldAttr(nst: 157, ctr: 149)] public bool _Bool_0x9d;
        [FieldAttr(nst: 160, ctr: 152)] public string? _Jump_0xa0 = null;
        [FieldAttr(nst: 168, ctr: 160)] public float _Float_0xa8;
        [FieldAttr(nst: 172, ctr: 164)] public float _Float_0xac;
    }
}
