namespace Alchemy
{
    [ObjectAttr(48, 16)]
    public class CPixelCostConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField _thresholds = new();
    }
}
