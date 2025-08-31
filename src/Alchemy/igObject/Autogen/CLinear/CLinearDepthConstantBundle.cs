namespace Alchemy
{
    [ObjectAttr(48, 16)]
    public class CLinearDepthConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField _parameters = new();
    }
}
