namespace Alchemy
{
    [ObjectAttr(64, 8, metaType: typeof(CDamageMessage))]
    public class CDamageMessage : CEntityMessage
    {
        [FieldAttr(56, false)] public CDamageInstance? _damage;
    }
}
