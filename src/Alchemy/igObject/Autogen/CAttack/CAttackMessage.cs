namespace Alchemy
{
    [ObjectAttr(64, 8, metaType: typeof(CAttackMessage))]
    public class CAttackMessage : CEntityMessage
    {
        [FieldAttr(56, false)] public CDamageInstance? _damage;
    }
}
