namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class B301_TinyTiger_CrowdManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float_0x28;
        [FieldAttr(nst: 44, ctr: 36)] public float _Float_0x2c;
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x30;
        [FieldAttr(nst: 52, ctr: 44)] public float _Float_0x34;
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Sound_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Sound_0x50 = new();
    }
}
