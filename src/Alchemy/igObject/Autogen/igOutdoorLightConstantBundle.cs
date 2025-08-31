namespace Alchemy
{
    [ObjectAttr(80, 16)]
    public class igOutdoorLightConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField _color = new();
        [FieldAttr(48)] public igVec4fMetaField _direction = new();
        [FieldAttr(64)] public igVec4fMetaField _ambientScale = new();
    }
}
