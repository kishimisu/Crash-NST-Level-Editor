namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class JuiceScene : JuiceVisual
    {
        [FieldAttr(40)] public float _dofX = 200.0f;
        [FieldAttr(44)] public float _dofY = 400.0f;
        [FieldAttr(48)] public float _dofZ = 3000.0f;
        [FieldAttr(52)] public float _dofW = 6500.0f;
        [FieldAttr(56)] public float _nearClipPlane = 32.0f;
        [FieldAttr(60)] public float _farClipPlane = 2.0f;
        [FieldAttr(64)] public JuiceAnimationList? _animList;
        [FieldAttr(72)] public JuiceFieldValueList? _prevAnimFieldValues;
        [FieldAttr(80)] public igCinematicAnimationInstanceList? _activeAnims;
        [FieldAttr(88)] public igObject? _dataBind;
        [FieldAttr(96)] public igDataBindingList? _dataBindingList;
        [FieldAttr(104)] public float _time;
    }
}
