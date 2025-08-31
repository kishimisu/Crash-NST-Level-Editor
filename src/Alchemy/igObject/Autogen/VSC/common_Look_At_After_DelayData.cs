namespace Alchemy
{
    // VSC object extracted from: common_Override_Camera_When_Idle.igz

    [ObjectAttr(96, metaType: typeof(CVscComponentData))]
    public class common_Look_At_After_DelayData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Entity = new();
        [FieldAttr(48)] public float _Float_0x30;
        [FieldAttr(56)] public igHandleMetaField _Camera_Base = new();
        [FieldAttr(64)] public float _Float_0x40;
        [FieldAttr(68)] public float _Float_0x44;
        [FieldAttr(72)] public igVec3fMetaField _Vec_3F_0x48 = new();
        [FieldAttr(84)] public igVec3fMetaField _Vec_3F_0x54 = new();
    }
}
