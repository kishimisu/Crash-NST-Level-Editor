namespace Alchemy
{
    [ObjectAttr(64, 16)]
    public class CDebugMipmapClampBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField _clamp = new();
        [FieldAttr(48)] public igVec4fMetaField _clamp2 = new();
    }
}
