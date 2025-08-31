namespace Alchemy
{
    // VSC object extracted from: common_RotatePlanet.igz

    [ObjectAttr(80, metaType: typeof(CVscComponentData))]
    public class common_RotatePlanetData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Entity_0x28 = new();
        [FieldAttr(48)] public igHandleMetaField _Entity_0x30 = new();
        [FieldAttr(56)] public igHandleMetaField _Bolt_Point_0x38 = new();
        [FieldAttr(64)] public igHandleMetaField _Bolt_Point_0x40 = new();
        [FieldAttr(72)] public float _Float;
    }
}
