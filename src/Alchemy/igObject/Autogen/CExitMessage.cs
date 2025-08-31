namespace Alchemy
{
    [ObjectAttr(64, 8, metaType: typeof(CExitMessage))]
    public class CExitMessage : CEntityMessage
    {
        [FieldAttr(56, false)] public CEntity? _activator;
    }
}
