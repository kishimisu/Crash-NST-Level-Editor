namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CutsceneActionPlaySound : CCutsceneAction
    {
        [FieldAttr(24)] public CSound? _sound;
        [FieldAttr(32)] public bool _playAtEnd;
        [FieldAttr(33)] public bool _continueAfterEnd;
    }
}
