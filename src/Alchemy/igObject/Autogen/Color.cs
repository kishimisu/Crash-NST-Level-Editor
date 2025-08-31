namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class Color : igObject
    {
        [FieldAttr(16)] public igVec4ucMetaField _storage = new();
    }
}
