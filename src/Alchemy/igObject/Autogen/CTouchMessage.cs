namespace Alchemy
{
    [ObjectAttr(64, 8, metaType: typeof(CTouchMessage))]
    public class CTouchMessage : CEntityMessage
    {
        [FieldAttr(56, false)] public CEntity? _activator;
    }
}
