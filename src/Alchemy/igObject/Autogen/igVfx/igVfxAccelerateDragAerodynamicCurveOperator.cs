namespace Alchemy
{
    [ObjectAttr(120, 4)]
    public class igVfxAccelerateDragAerodynamicCurveOperator : igVfxAccelerateDragAerodynamicBaseOperator
    {
        [FieldAttr(32)] public igVfxRangedCurveMetaField _drag = new();
        [FieldAttr(116)] public EOperatorCurveInput _dragInput;
    }
}
