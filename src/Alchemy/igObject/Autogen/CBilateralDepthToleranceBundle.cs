namespace Alchemy
{
    [ObjectAttr(48, 16)]
    public class CBilateralDepthToleranceBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField _bilateralToleranceScales = new();
    }
}
