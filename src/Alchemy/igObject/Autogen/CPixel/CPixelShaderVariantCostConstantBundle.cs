namespace Alchemy
{
    [ObjectAttr(4128, 16)]
    public class CPixelShaderVariantCostConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(32)] public igVec4fMetaField[] _variantCost = new igVec4fMetaField[256];
    }
}
