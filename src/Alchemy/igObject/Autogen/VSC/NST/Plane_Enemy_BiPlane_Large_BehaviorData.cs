namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(CVscComponentData))]
    public class Plane_Enemy_BiPlane_Large_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _String = null;
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x30;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Debug_Update_Channel = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Entity_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Bolt_Point_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Entity_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public float _Float_0x58;
        [FieldAttr(nst: 92, ctr: 84)] public float _Float_0x5c;
        [FieldAttr(nst: 96, ctr: 88)] public float _Float_0x60;
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Bolt_Point_0x68 = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Entity_0x70 = new();
        [FieldAttr(nst: 120, ctr: 112)] public float _Float_0x78;
        [FieldAttr(nst: 124, ctr: 116)] public float _Float_0x7c;
    }
}
