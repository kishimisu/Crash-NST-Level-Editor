namespace Alchemy
{
    // VSC object extracted from: Hazard_HavokBased_Chase_Behavior.igz

    [ObjectAttr(216, metaType: typeof(CVscComponentData))]
    public class Hazard_HavokBased_Chase_BehaviorData : CVscComponentData
    {
        public enum ENewEnum14_id_4flii4az
        {
            Stop = 0,
            Falling = 1,
        }

        [FieldAttr(40)] public igHandleMetaField _OptionalTrigger = new();
        [FieldAttr(48)] public string? _String_0x30 = null;
        [FieldAttr(56)] public igHandleMetaField _SplineSnapAttachBehavior = new();
        [FieldAttr(64)] public igHandleMetaField _SplineRotationMover = new();
        [FieldAttr(72)] public igHandleMetaField _SplineVelocityMover = new();
        [FieldAttr(80)] public string? _String_0x50 = null;
        [FieldAttr(88)] public float _Float_0x58;
        [FieldAttr(92)] public float _Float_0x5c;
        [FieldAttr(96)] public float _Float_0x60;
        [FieldAttr(100)] public ENewEnum14_id_4flii4az _NewEnum14_id_4flii4az;
        [FieldAttr(104)] public string? _String_0x68 = null;
        [FieldAttr(112)] public float _Float_0x70;
        [FieldAttr(120)] public string? _String_0x78 = null;
        [FieldAttr(128)] public igHandleMetaField _Spline_Event_0x80 = new();
        [FieldAttr(136)] public bool _DestroyAtEnd;
        [FieldAttr(137)] public bool _Bool_0x89;
        [FieldAttr(144)] public string? _String_0x90 = null;
        [FieldAttr(152)] public igHandleMetaField _Entity = new();
        [FieldAttr(160)] public bool _Bool_0xa0;
        [FieldAttr(161)] public bool _Bool_0xa1;
        [FieldAttr(164)] public float _Float_0xa4;
        [FieldAttr(168)] public string? _String_0xa8 = null;
        [FieldAttr(176)] public string? _String_0xb0 = null;
        [FieldAttr(184)] public float _Float_0xb8;
        [FieldAttr(188)] public float _Float_0xbc;
        [FieldAttr(192)] public float _Float_0xc0;
        [FieldAttr(196)] public float _Float_0xc4;
        [FieldAttr(200)] public string? _String_0xc8 = null;
        [FieldAttr(208)] public igHandleMetaField _Spline_Event_0xd0 = new();
    }
}
