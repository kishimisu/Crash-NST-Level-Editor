namespace Alchemy
{
    [ObjectAttr(48, 16)]
    public class CRenderTimeBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField _time = new();
    }
}
