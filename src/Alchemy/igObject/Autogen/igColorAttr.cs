namespace Alchemy
{
    [ObjectAttr(48, 16)]
    public class igColorAttr : igVisualAttribute
    {
        [FieldAttr(32)] public igVec4fMetaField _color = new();
    }
}
