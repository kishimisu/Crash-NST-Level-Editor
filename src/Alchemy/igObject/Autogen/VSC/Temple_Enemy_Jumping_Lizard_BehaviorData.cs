namespace Alchemy
{
    // VSC object extracted from: Temple_Enemy_Jumping_Lizard_Behavior_c.igz

    [ObjectAttr(176, metaType: typeof(CVscComponentData))]
    public class Temple_Enemy_Jumping_Lizard_BehaviorData : CVscComponentData
    {
        public enum EStartingDirection
        {
            CountUp = 0,
            CountDown = 1,
        }

        [FieldAttr(40)] public bool _TrackPlayer;
        [FieldAttr(41)] public bool _SetStartingPostion;
        [FieldAttr(48)] public igHandleMetaField _TargetList = new();
        [FieldAttr(56)] public EStartingDirection _StartingDirection;
        [FieldAttr(60)] public float _JumpHeight;
        [FieldAttr(64)] public float _JumpDuration;
        [FieldAttr(68)] public float _PauseBetweenJumps;
        [FieldAttr(72)] public int _StartingIndex;
        [FieldAttr(80)] public string? _Jump_0x50 = null;
        [FieldAttr(88)] public string? _Idle = null;
        [FieldAttr(96)] public string? _Land = null;
        [FieldAttr(104)] public float _Float_0x68;
        [FieldAttr(108)] public float _Float_0x6c;
        [FieldAttr(112)] public string? _String_0x70 = null;
        [FieldAttr(120)] public float _Float_0x78;
        [FieldAttr(124)] public float _Float_0x7c;
        [FieldAttr(128)] public string? _Jump_0x80 = null;
        [FieldAttr(136)] public float _Range;
        [FieldAttr(140)] public bool _Bool_0x8c;
        [FieldAttr(144)] public string? _String_0x90 = null;
        [FieldAttr(152)] public float _Float_0x98;
        [FieldAttr(156)] public bool _Bool_0x9c;
        [FieldAttr(157)] public bool _Bool_0x9d;
        [FieldAttr(160)] public string? _Jump_0xa0 = null;
        [FieldAttr(168)] public float _Float_0xa8;
        [FieldAttr(172)] public float _Float_0xac;
    }
}
