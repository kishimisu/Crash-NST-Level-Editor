namespace Alchemy
{
    [ObjectAttr(nst: 216, ctr: 208, align: 4, metaType: typeof(CVscComponentData))]
    public class Hazard_HavokBased_Chase_BehaviorData : CVscComponentData
    {
        public enum ENewEnum14_id_4flii4az
        {
            Stop = 0,
            Falling = 1,
        }

        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _OptionalTrigger = new();
        [FieldAttr(nst: 48, ctr: 40)] public string? _String_0x30 = null;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _SplineSnapAttachBehavior = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _SplineRotationMover = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _SplineVelocityMover = new();
        [FieldAttr(nst: 80, ctr: 72)] public string? _String_0x50 = null;
        [FieldAttr(nst: 88, ctr: 80)] public float _Float_0x58;
        [FieldAttr(nst: 92, ctr: 84)] public float _Float_0x5c;
        [FieldAttr(nst: 96, ctr: 88)] public float _Float_0x60;
        [FieldAttr(nst: 100, ctr: 92)] public ENewEnum14_id_4flii4az _NewEnum14_id_4flii4az;
        [FieldAttr(nst: 104, ctr: 96)] public string? _String_0x68 = null;
        [FieldAttr(nst: 112, ctr: 104)] public float _Float_0x70;
        [FieldAttr(nst: 120, ctr: 112)] public string? _String_0x78 = null;
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Spline_Event_0x80 = new();
        [FieldAttr(nst: 136, ctr: 128)] public bool _DestroyAtEnd;
        [FieldAttr(nst: 137, ctr: 129)] public bool _Bool_0x89;
        [FieldAttr(nst: 144, ctr: 136)] public string? _String_0x90 = null;
        [FieldAttr(nst: 152, ctr: 144)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 160, ctr: 152)] public bool _Bool_0xa0;
        [FieldAttr(nst: 161, ctr: 153)] public bool _Bool_0xa1;
        [FieldAttr(nst: 164, ctr: 156)] public float _Float_0xa4;
        [FieldAttr(nst: 168, ctr: 160)] public string? _String_0xa8 = null;
        [FieldAttr(nst: 176, ctr: 168)] public string? _String_0xb0 = null;
        [FieldAttr(nst: 184, ctr: 176)] public float _Float_0xb8;
        [FieldAttr(nst: 188, ctr: 180)] public float _Float_0xbc;
        [FieldAttr(nst: 192, ctr: 184)] public float _Float_0xc0;
        [FieldAttr(nst: 196, ctr: 188)] public float _Float_0xc4;
        [FieldAttr(nst: 200, ctr: 192)] public string? _String_0xc8 = null;
        [FieldAttr(nst: 208, ctr: 200)] public igHandleMetaField _Spline_Event_0xd0 = new();
    }
}
