namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igGraphicsShader : igGraphicsObject
    {
        [FieldAttr(24)] public igTextureSamplerSourceList? _samplerList;
        [FieldAttr(32)] public igGfxShaderConstantList? _stateList;
        [FieldAttr(40)] public igShaderBuffer? _shaderBuffer;
        [FieldAttr(48)] public igSizeTypeMetaField _resource = new();
    }
}
