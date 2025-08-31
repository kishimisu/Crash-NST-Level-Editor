namespace Alchemy
{
    [ObjectAttr(96, 16)]
    public class igVfxColorRangedRampOperator : igVfxColorBaseOperator
    {
        [FieldAttr(32)] public igVec4fMetaField _colorMinStart = new();
        [FieldAttr(48)] public igVec4fMetaField _colorMaxStart = new();
        [FieldAttr(64)] public igVec4fMetaField _colorMinEnd = new();
        [FieldAttr(80)] public igVec4fMetaField _colorMaxEnd = new();
    }
}
