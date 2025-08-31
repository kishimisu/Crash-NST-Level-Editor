namespace Alchemy
{
    [ObjectAttr(48, 16)]
    public class CGlobalWindShaderConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField _windParameters = new();
    }
}
