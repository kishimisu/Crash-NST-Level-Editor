namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Prehistoric_Hazard_LavaData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Collision_Material = new();
        [FieldAttr(nst: 48, ctr: 40)] public string? _CrashDeath = null;
        [FieldAttr(nst: 56, ctr: 48)] public bool _Bool;
    }
}
