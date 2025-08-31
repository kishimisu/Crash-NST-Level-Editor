namespace Alchemy
{
    // VSC object extracted from: common_Exploding_Dynamic_Object_c.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class common_Exploding_Dynamic_ObjectData : CVscComponentData
    {
        [FieldAttr(40)] public float _Lifetime;
        [FieldAttr(48)] public string? _CrashDeath = null;
        [FieldAttr(56)] public igHandleMetaField _Explosion_Vfx_Effect = new();
    }
}
