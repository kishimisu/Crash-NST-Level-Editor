namespace Alchemy
{
    [ObjectAttr(72, 8, metaType: typeof(CDeathMessage))]
    public class CDeathMessage : CEntityMessage
    {
        [FieldAttr(56, false)] public CEntity? _killer;
        [FieldAttr(64, false)] public CDamageInstance? _damage;
    }
}
