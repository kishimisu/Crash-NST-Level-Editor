namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Exploding_Dynamic_ObjectData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Lifetime;
        [FieldAttr(nst: 48, ctr: 40)] public string? _CrashDeath = null;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Explosion_Vfx_Effect = new();
    }
}
