namespace Alchemy
{
    [ObjectAttr(64, 8, metaType: typeof(CCustomEvent))]
    public class CCustomEvent : CEntityMessage
    {
        [FieldAttr(56)] public string? _name = null;
    }
}
