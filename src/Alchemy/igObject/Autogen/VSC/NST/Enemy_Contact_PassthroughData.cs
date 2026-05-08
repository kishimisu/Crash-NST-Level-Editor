namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Contact_PassthroughData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 56, ctr: 48)] public bool _Bool_0x38;
        [FieldAttr(nst: 57, ctr: 49)] public bool _Bool_0x39;
        [FieldAttr(nst: 58, ctr: 50)] public bool _Bool_0x3a;
        [FieldAttr(nst: 60, ctr: 52)] public float _Float;
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool_0x40;
        [FieldAttr(nst: 65, ctr: 57)] public bool _Bool_0x41;
        [FieldAttr(nst: 66, ctr: 58)] public bool _Bool_0x42;
        [FieldAttr(nst: 67, ctr: 59)] public bool _Bool_0x43;
        [FieldAttr(nst: 68, ctr: 60)] public bool _Bool_0x44;
        [FieldAttr(nst: 69, ctr: 61)] public bool _Bool_0x45;
        [FieldAttr(nst: 72, ctr: 64)] public string? _String = null;
        [FieldAttr(nst: 80, ctr: 72)] public bool _Bool_0x50;
        [FieldAttr(nst: 81, ctr: 73)] public bool _Bool_0x51;
    }
}
