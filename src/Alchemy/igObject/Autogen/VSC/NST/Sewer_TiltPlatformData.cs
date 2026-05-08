namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class Sewer_TiltPlatformData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float_0x28;
        [FieldAttr(nst: 44, ctr: 36)] public float _Float_0x2c;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Havok_Ball_And_Socket_Constraint_Data = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Havok_Stiff_Spring_Constraint_Data = new();
    }
}
