namespace Alchemy
{
    // VSC object extracted from: common_SplineMover_NoDrift.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class common_SplineMover_NoDriftData : CVscComponentData
    {
        [FieldAttr(40)] public float _Float;
        [FieldAttr(44)] public bool _Bool;
        [FieldAttr(48)] public igHandleMetaField _Sound = new();
        [FieldAttr(56)] public igHandleMetaField _Vfx_Effect = new();
    }
}
