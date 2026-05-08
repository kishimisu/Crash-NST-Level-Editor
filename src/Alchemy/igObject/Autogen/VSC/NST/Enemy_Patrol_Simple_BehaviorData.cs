namespace Alchemy
{
    [ObjectAttr(nst: 192, ctr: 184, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Patrol_Simple_BehaviorData : CVscComponentData
    {
        public enum ENewEnum3_id_hxyr1b9k
        {
            PingPong = 0,
            Wrap = 1,
            SinglePlay = 2,
        }

        [FieldAttr(nst: 40, ctr: 32)] public bool _JumpWhenTurning;
        [FieldAttr(nst: 41, ctr: 33)] public bool _AttachOnStart;
        [FieldAttr(nst: 42, ctr: 34)] public bool _SpinWhenMoving;
        [FieldAttr(nst: 43, ctr: 35)] public bool _SpinWhenTurning;
        [FieldAttr(nst: 44, ctr: 36)] public bool _JumpWhenMoving;
        [FieldAttr(nst: 48, ctr: 40)] public float _StartingRatio;
        [FieldAttr(nst: 52, ctr: 44)] public float _WalkBackSpeed;
        [FieldAttr(nst: 56, ctr: 48)] public float _TurnBlend;
        [FieldAttr(nst: 60, ctr: 52)] public float _WalkForwardSpeed;
        [FieldAttr(nst: 64, ctr: 56)] public float _WalkForwardBlend;
        [FieldAttr(nst: 68, ctr: 60)] public float _WalkBackBlend;
        [FieldAttr(nst: 72, ctr: 64)] public float _TurnDelay;
        [FieldAttr(nst: 80, ctr: 72)] public string? _WalkBack = null;
        [FieldAttr(nst: 88, ctr: 80)] public string? _TurnToFront = null;
        [FieldAttr(nst: 96, ctr: 88)] public string? _TurnToBack = null;
        [FieldAttr(nst: 104, ctr: 96)] public string? _Idle = null;
        [FieldAttr(nst: 112, ctr: 104)] public string? _WalkForward = null;
        [FieldAttr(nst: 120, ctr: 112)] public ENewEnum3_id_hxyr1b9k _NewEnum3_id_hxyr1b9k;
        [FieldAttr(nst: 124, ctr: 116)] public bool _Bool_0x7c;
        [FieldAttr(nst: 125, ctr: 117)] public bool _Bool_0x7d;
        [FieldAttr(nst: 126, ctr: 118)] public bool _Bool_0x7e;
        [FieldAttr(nst: 127, ctr: 119)] public bool _Bool_0x7f;
        [FieldAttr(nst: 128, ctr: 120)] public int _Int_0x80;
        [FieldAttr(nst: 132, ctr: 124)] public bool _Bool_0x84;
        [FieldAttr(nst: 133, ctr: 125)] public bool _Bool_0x85;
        [FieldAttr(nst: 136, ctr: 128)] public int _Int_0x88;
        [FieldAttr(nst: 140, ctr: 132)] public int _Int_0x8c;
        [FieldAttr(nst: 144, ctr: 136)] public bool _Bool_0x90;
        [FieldAttr(nst: 152, ctr: 144)] public igHandleMetaField _Sound_0x98 = new();
        [FieldAttr(nst: 160, ctr: 152)] public igHandleMetaField _Sound_0xa0 = new();
        [FieldAttr(nst: 168, ctr: 160)] public bool _PlayForward;
        [FieldAttr(nst: 176, ctr: 168)] public string? _String_0xb0 = null;
        [FieldAttr(nst: 184, ctr: 176)] public string? _String_0xb8 = null;
    }
}
