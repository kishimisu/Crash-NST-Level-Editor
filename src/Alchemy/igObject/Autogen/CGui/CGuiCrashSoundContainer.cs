namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CGuiCrashSoundContainer : CGuiBaseSoundContainer
    {
        [FieldAttr(24)] public CGuiMenuSoundTable? _crash1MenuSoundTable;
        [FieldAttr(32)] public CGuiMenuSoundTable? _crash2MenuSoundTable;
        [FieldAttr(40)] public CGuiMenuSoundTable? _crash3MenuSoundTable;
    }
}
