namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Look_At_After_DelayData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x30;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Camera_Base = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _Float_0x40;
        [FieldAttr(nst: 68, ctr: 60)] public float _Float_0x44;
        [FieldAttr(nst: 72, ctr: 64)] public igVec3fMetaField _Vec_3F_0x48 = new();
        [FieldAttr(nst: 84, ctr: 76)] public igVec3fMetaField _Vec_3F_0x54 = new();
    }
}
