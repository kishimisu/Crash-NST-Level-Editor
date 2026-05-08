namespace Alchemy
{
    [ObjectAttr(nst: 168, ctr: 160, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Patrol_MultipleStates_BehaviorData : CVscComponentData
    {
        public enum ENewEnum11_id_fhqgj4mh
        {
            State01 = 0,
            State02 = 1,
            SwitchByTimer = 2,
            SwitchByTriggerVolume = 3,
        }

        [FieldAttr(nst: 40, ctr: 32)] public float _WalkForwardSpeed;
        [FieldAttr(nst: 44, ctr: 36)] public float _WalkForwardBlend;
        [FieldAttr(nst: 48, ctr: 40)] public bool _Bool_0x30;
        [FieldAttr(nst: 52, ctr: 44)] public ENewEnum11_id_fhqgj4mh _NewEnum11_id_fhqgj4mh;
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
        [FieldAttr(nst: 60, ctr: 52)] public bool _Bool_0x3c;
        [FieldAttr(nst: 61, ctr: 53)] public bool _Bool_0x3d;
        [FieldAttr(nst: 62, ctr: 54)] public bool _Bool_0x3e;
        [FieldAttr(nst: 63, ctr: 55)] public bool _Bool_0x3f;
        [FieldAttr(nst: 64, ctr: 56)] public string? _String_0x40 = null;
        [FieldAttr(nst: 72, ctr: 64)] public string? _String_0x48 = null;
        [FieldAttr(nst: 80, ctr: 72)] public string? _String_0x50 = null;
        [FieldAttr(nst: 88, ctr: 80)] public float _Float_0x58;
        [FieldAttr(nst: 96, ctr: 88)] public string? _String_0x60 = null;
        [FieldAttr(nst: 104, ctr: 96)] public string? _String_0x68 = null;
        [FieldAttr(nst: 112, ctr: 104)] public string? _String_0x70 = null;
        [FieldAttr(nst: 120, ctr: 112)] public bool _Bool_0x78;
        [FieldAttr(nst: 121, ctr: 113)] public bool _Bool_0x79;
        [FieldAttr(nst: 122, ctr: 114)] public bool _Bool_0x7a;
        [FieldAttr(nst: 123, ctr: 115)] public bool _Bool_0x7b;
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 136, ctr: 128)] public bool _Bool_0x88;
        [FieldAttr(nst: 137, ctr: 129)] public bool _Bool_0x89;
        [FieldAttr(nst: 140, ctr: 132)] public float _Float_0x8c;
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _Count = new();
        [FieldAttr(nst: 152, ctr: 144)] public igHandleMetaField _DamagedInvulnerable = new();
        [FieldAttr(nst: 160, ctr: 152)] public igHandleMetaField _AkuAkuInvinciblityActive = new();
    }
}
