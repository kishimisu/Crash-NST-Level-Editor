namespace Alchemy
{
    // VSC object extracted from: Common_Spawn_Prop_OnDeath.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class Common_Spawn_Prop_OnDeathData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(48)] public igHandleMetaField _Entity = new();
        [FieldAttr(56)] public string? _String = null;
    }
}
