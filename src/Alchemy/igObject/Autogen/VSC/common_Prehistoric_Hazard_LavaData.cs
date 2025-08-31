namespace Alchemy
{
    // VSC object extracted from: common_Prehistoric_Hazard_Lava.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class common_Prehistoric_Hazard_LavaData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Collision_Material = new();
        [FieldAttr(48)] public string? _CrashDeath = null;
        [FieldAttr(56)] public bool _Bool;
    }
}
