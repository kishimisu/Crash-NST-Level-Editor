namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igGraphicsShaderVariant : igGraphicsObject
    {
        [FieldAttr(24)] public igStringRefList? _shaderConstants;
        [FieldAttr(32)] public igIntList? _elementIndices;
        [FieldAttr(40)] public igIntList? _variantSizes;
        [FieldAttr(48)] public igGraphicsShaderList? _shaders;
        [FieldAttr(56)] public igShaderVariant2? _variant;
    }
}
