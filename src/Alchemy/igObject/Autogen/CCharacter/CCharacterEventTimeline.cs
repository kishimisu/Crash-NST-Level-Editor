namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CCharacterEventTimeline : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _clip = new();
        [FieldAttr(24)] public CCombatNodeEventList? _events;
    }
}
