namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CGuiSoundContainer : CGuiBaseSoundContainer
    {
        [FieldAttr(24)] public CGuiMenuSoundTable? _guiMenuSoundTable;
    }
}
