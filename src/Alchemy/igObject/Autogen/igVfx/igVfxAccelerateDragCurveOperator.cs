namespace Alchemy
{
    [ObjectAttr(120, 4)]
    public class igVfxAccelerateDragCurveOperator : igVfxAccelerateDragBaseOperator
    {
        [FieldAttr(32)] public igVfxRangedCurveMetaField _drag = new();
        [FieldAttr(116)] public EOperatorCurveInput _dragInput;
    }
}
