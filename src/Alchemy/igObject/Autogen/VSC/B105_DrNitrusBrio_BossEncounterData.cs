namespace Alchemy
{
    // VSC object extracted from: B105_DrNitrusBrio_BossEncounter_c.igz

    [ObjectAttr(80, metaType: typeof(CVscComponentData))]
    public class B105_DrNitrusBrio_BossEncounterData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Boss = new();
        [FieldAttr(48)] public igHandleMetaField _IntroCutscene = new();
        [FieldAttr(56)] public igHandleMetaField _BossDefeatDestructibleTemplateList = new();
        [FieldAttr(64)] public igHandleMetaField _BossDefeatFallTrigger = new();
        [FieldAttr(72)] public igHandleMetaField _Waypoint = new();
    }
}
