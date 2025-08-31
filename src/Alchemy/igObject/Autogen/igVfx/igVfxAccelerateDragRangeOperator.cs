namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class igVfxAccelerateDragRangeOperator : igVfxAccelerateDragBaseOperator
    {
        [FieldAttr(32)] public igRangedFloatMetaField _drag = new();
    }
}
