namespace Alchemy
{
    [ObjectAttr(nst: 120, ctr: 112, align: 4, metaType: typeof(CVscComponentData))]
    public class BossTinyTigerC3_Lion_AiBossManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Bolt_Point_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
        [FieldAttr(nst: 60, ctr: 52)] public EigEaseType _Ease_Type_0x3c;
        [FieldAttr(nst: 64, ctr: 56)] public float _Float_0x40;
        [FieldAttr(nst: 68, ctr: 60)] public float _Float_0x44;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Bolt_Point_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Damage_Data = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _String_List = new();
        [FieldAttr(nst: 96, ctr: 88)] public float _Float_0x60;
        [FieldAttr(nst: 100, ctr: 92)] public float _Float_0x64;
        [FieldAttr(nst: 104, ctr: 96)] public EigEaseType _Ease_Type_0x68;
        [FieldAttr(nst: 108, ctr: 100)] public float _Float_0x6c;
        [FieldAttr(nst: 112, ctr: 104)] public float _Float_0x70;
        [FieldAttr(nst: 116, ctr: 108)] public float _Float_0x74;
    }
}
