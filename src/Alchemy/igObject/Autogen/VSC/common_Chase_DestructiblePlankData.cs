namespace Alchemy
{
    // VSC object extracted from: common_Chase_DestructiblePlank.igz

    [ObjectAttr(80, metaType: typeof(CVscComponentData))]
    public class common_Chase_DestructiblePlankData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _RequiredTag = new();
        [FieldAttr(48)] public float _Float;
        [FieldAttr(56)] public igHandleMetaField _HitSound = new();
        [FieldAttr(64)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(72)] public igHandleMetaField _Entity = new();
    }
}
