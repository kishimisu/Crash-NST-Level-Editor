namespace Alchemy
{
    // VSC object extracted from: Enemy_Patrol_Simple_Behavior_c.igz

    [ObjectAttr(192, metaType: typeof(CVscComponentData))]
    public class Enemy_Patrol_Simple_BehaviorData : CVscComponentData
    {
        public enum ENewEnum3_id_hxyr1b9k
        {
            PingPong = 0,
            Wrap = 1,
            SinglePlay = 2,
        }

        [FieldAttr(40)] public bool _JumpWhenTurning;
        [FieldAttr(41)] public bool _AttachOnStart;
        [FieldAttr(42)] public bool _SpinWhenMoving;
        [FieldAttr(43)] public bool _SpinWhenTurning;
        [FieldAttr(44)] public bool _JumpWhenMoving;
        [FieldAttr(48)] public float _StartingRatio;
        [FieldAttr(52)] public float _WalkBackSpeed;
        [FieldAttr(56)] public float _TurnBlend;
        [FieldAttr(60)] public float _WalkForwardSpeed;
        [FieldAttr(64)] public float _WalkForwardBlend;
        [FieldAttr(68)] public float _WalkBackBlend;
        [FieldAttr(72)] public float _TurnDelay;
        [FieldAttr(80)] public string? _WalkBack = null;
        [FieldAttr(88)] public string? _TurnToFront = null;
        [FieldAttr(96)] public string? _TurnToBack = null;
        [FieldAttr(104)] public string? _Idle = null;
        [FieldAttr(112)] public string? _WalkForward = null;
        [FieldAttr(120)] public ENewEnum3_id_hxyr1b9k _NewEnum3_id_hxyr1b9k;
        [FieldAttr(124)] public bool _Bool_0x7c;
        [FieldAttr(125)] public bool _Bool_0x7d;
        [FieldAttr(126)] public bool _Bool_0x7e;
        [FieldAttr(127)] public bool _Bool_0x7f;
        [FieldAttr(128)] public int _Int_0x80;
        [FieldAttr(132)] public bool _Bool_0x84;
        [FieldAttr(133)] public bool _Bool_0x85;
        [FieldAttr(136)] public int _Int_0x88;
        [FieldAttr(140)] public int _Int_0x8c;
        [FieldAttr(144)] public bool _Bool_0x90;
        [FieldAttr(152)] public igHandleMetaField _Sound_0x98 = new();
        [FieldAttr(160)] public igHandleMetaField _Sound_0xa0 = new();
        [FieldAttr(168)] public bool _PlayForward;
        [FieldAttr(176)] public string? _String_0xb0 = null;
        [FieldAttr(184)] public string? _String_0xb8 = null;
    }
}
