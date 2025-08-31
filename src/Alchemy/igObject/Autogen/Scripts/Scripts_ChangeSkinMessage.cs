namespace Alchemy
{
    [ObjectAttr(64, 8, metaType: typeof(CEntityMessage))]
    public class Scripts_ChangeSkinMessage : CEntityMessage
    {
        [FieldAttr(56)] public bool ActivateBaseSkin = true;
    }
}
