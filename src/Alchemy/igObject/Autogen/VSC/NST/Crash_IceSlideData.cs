namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class Crash_IceSlideData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _IceIdle = null;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Collision_Material_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _Float;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Collision_Material_0x40 = new();
    }
}
