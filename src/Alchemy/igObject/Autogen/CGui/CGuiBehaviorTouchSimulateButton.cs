namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CGuiBehaviorTouchSimulateButton : igGuiBehavior
    {
        [FieldAttr(16)] public igGuiInput.ESignal _button;
        [FieldAttr(20)] public bool _hideWhenOnSubScreen;
        [FieldAttr(24)] public igGuiInput.EController _touchControl;
    }
}
