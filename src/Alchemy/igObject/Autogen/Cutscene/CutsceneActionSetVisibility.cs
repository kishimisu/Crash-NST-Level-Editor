namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CutsceneActionSetVisibility : CCutsceneAction
    {
        [FieldAttr(24)] public CCutsceneActor? _actor;
        [FieldAttr(32)] public bool _isVisible;
    }
}
