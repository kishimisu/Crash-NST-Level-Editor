namespace Alchemy
{
    [ObjectAttr(64, 8, metaType: typeof(CDamageAttemptMessage))]
    public class CDamageAttemptMessage : CEntityMessage
    {
        [FieldAttr(56, false)] public CDamageInstance? _damage;
    }
}
