namespace Alchemy
{
    [ObjectAttr(72, 8, metaType: typeof(CPlayerMessage))]
    public class Scripts_StringMessage : CPlayerMessage
    {
        [FieldAttr(64)] public string? MessageString = "";
    }
}
