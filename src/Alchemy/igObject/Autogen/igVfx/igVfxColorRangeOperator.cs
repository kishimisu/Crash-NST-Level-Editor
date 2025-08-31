namespace Alchemy
{
    [ObjectAttr(64, 16)]
    public class igVfxColorRangeOperator : igVfxColorBaseOperator
    {
        [FieldAttr(32)] public igVec4fMetaField _colorMin = new();
        [FieldAttr(48)] public igVec4fMetaField _colorMax = new();
    }
}
