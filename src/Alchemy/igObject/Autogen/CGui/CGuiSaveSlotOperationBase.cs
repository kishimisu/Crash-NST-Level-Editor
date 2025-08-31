namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CGuiSaveSlotOperationBase : igObject
    {
        [FieldAttr(16)] public CGuiSaveSlotAnimations? _animations;
        [FieldAttr(24)] public EigGuiAnimationLoopMode _animIdleLoopMode = EigGuiAnimationLoopMode.kGuiLoopRepeat;
        [FieldAttr(32)] public igGuiAnimationCategory? _animationCategory;
        [FieldAttr(40)] public int _currentSlot = -1;
        [FieldAttr(44)] public bool _completedSuccessfully;
        [FieldAttr(48)] public EButtonLegendButton _button;
        [FieldAttr(56)] public string? _legendText = null;
        [FieldAttr(64)] public bool _legendTextAdded;
    }
}
