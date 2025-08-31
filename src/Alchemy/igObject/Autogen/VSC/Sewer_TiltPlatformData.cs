namespace Alchemy
{
    // VSC object extracted from: Sewer_TiltPlatform.igz

    [ObjectAttr(72, metaType: typeof(CVscComponentData))]
    public class Sewer_TiltPlatformData : CVscComponentData
    {
        [FieldAttr(40)] public float _Float_0x28;
        [FieldAttr(44)] public float _Float_0x2c;
        [FieldAttr(48)] public igHandleMetaField _Entity = new();
        [FieldAttr(56)] public igHandleMetaField _Havok_Ball_And_Socket_Constraint_Data = new();
        [FieldAttr(64)] public igHandleMetaField _Havok_Stiff_Spring_Constraint_Data = new();
    }
}
