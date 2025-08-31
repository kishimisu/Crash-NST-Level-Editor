namespace Alchemy
{
    // VSC object extracted from: Enemy_Patrol_MultipleStates_Behavior.igz

    [ObjectAttr(168, metaType: typeof(CVscComponentData))]
    public class Enemy_Patrol_MultipleStates_BehaviorData : CVscComponentData
    {
        public enum ENewEnum11_id_fhqgj4mh
        {
            State01 = 0,
            State02 = 1,
            SwitchByTimer = 2,
            SwitchByTriggerVolume = 3,
        }

        [FieldAttr(40)] public float _WalkForwardSpeed;
        [FieldAttr(44)] public float _WalkForwardBlend;
        [FieldAttr(48)] public bool _Bool_0x30;
        [FieldAttr(52)] public ENewEnum11_id_fhqgj4mh _NewEnum11_id_fhqgj4mh;
        [FieldAttr(56)] public float _Float_0x38;
        [FieldAttr(60)] public bool _Bool_0x3c;
        [FieldAttr(61)] public bool _Bool_0x3d;
        [FieldAttr(62)] public bool _Bool_0x3e;
        [FieldAttr(63)] public bool _Bool_0x3f;
        [FieldAttr(64)] public string? _String_0x40 = null;
        [FieldAttr(72)] public string? _String_0x48 = null;
        [FieldAttr(80)] public string? _String_0x50 = null;
        [FieldAttr(88)] public float _Float_0x58;
        [FieldAttr(96)] public string? _String_0x60 = null;
        [FieldAttr(104)] public string? _String_0x68 = null;
        [FieldAttr(112)] public string? _String_0x70 = null;
        [FieldAttr(120)] public bool _Bool_0x78;
        [FieldAttr(121)] public bool _Bool_0x79;
        [FieldAttr(122)] public bool _Bool_0x7a;
        [FieldAttr(123)] public bool _Bool_0x7b;
        [FieldAttr(128)] public igHandleMetaField _Entity = new();
        [FieldAttr(136)] public bool _Bool_0x88;
        [FieldAttr(137)] public bool _Bool_0x89;
        [FieldAttr(140)] public float _Float_0x8c;
        [FieldAttr(144)] public igHandleMetaField _Count = new();
        [FieldAttr(152)] public igHandleMetaField _DamagedInvulnerable = new();
        [FieldAttr(160)] public igHandleMetaField _AkuAkuInvinciblityActive = new();
    }
}
