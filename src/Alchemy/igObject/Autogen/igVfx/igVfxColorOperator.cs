namespace Alchemy
{
    [ObjectAttr(48, 16)]
    public class igVfxColorOperator : igVfxColorBaseOperator
    {
        [FieldAttr(32)] public igVec4fMetaField _color = new();
    }
}
