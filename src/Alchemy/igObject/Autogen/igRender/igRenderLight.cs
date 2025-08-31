namespace Alchemy
{
    [ObjectAttr(80, 16)]
    public class igRenderLight : igNamedObject
    {
        [FieldAttr(32)] public igVec4fMetaField _color = new();
        [FieldAttr(48)] public igVec3fMetaField _position = new();
        [FieldAttr(60)] public float _intensity = 1.0f;
        [FieldAttr(64)] public uint _flags = 1;
    }
}
