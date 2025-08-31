namespace Alchemy
{
    [ObjectAttr(64, 8, metaType: typeof(CEnterMessage))]
    public class CEnterMessage : CEntityMessage
    {
        [FieldAttr(56, false)] public CEntity? _activator;
    }
}
