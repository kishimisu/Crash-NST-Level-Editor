namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CutsceneActionPlayVO : CCutsceneAction
    {
        [FieldAttr(24)] public string? _wavFile = null;
        [FieldAttr(32)] public string? _subtitleString = null;
    }
}
