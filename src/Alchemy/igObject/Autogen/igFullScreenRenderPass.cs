namespace Alchemy
{
    [ObjectAttr(592, 16)]
    public class igFullScreenRenderPass : igSceneRenderPass
    {
        [FieldAttr(464)] public int _tileWidth = 2147483647;
        [FieldAttr(468)] public int _tileHeight = 2147483647;
        [FieldAttr(472)] public bool _enableDepthTest;
        [FieldAttr(473)] public bool _enableDepthWrite;
        [FieldAttr(476)] public int _texCoordCountOverride = -1;
        [FieldAttr(480)] public igRawRefMetaField _pixelShaderBinary = new();
        [FieldAttr(488)] public int _pixelShaderBinarySize;
        [FieldAttr(496)] public string? _pixelShaderStates = null;
        [FieldAttr(504)] public bool _pixelShaderNull;
        [FieldAttr(512)] public igRawRefMetaField _vertexShaderBinary = new();
        [FieldAttr(520)] public int _vertexShaderBinarySize;
        [FieldAttr(528)] public string? _vertexShaderStates = null;
        [FieldAttr(536)] public igShaderParametersAttr? _shaderParams;
        [FieldAttr(544)] public igFullScreenQuadDrawCall? _drawCall;
        [FieldAttr(552)] public igRawRefMetaField _sizeChangeCallback = new();
        [FieldAttr(560)] public igRawRefMetaField _sizeChangeCallbackArg = new();
        [FieldAttr(568)] public bool _flipUVs;
        [FieldAttr(572)] public igVec2fMetaField _texelOffset = new();
    }
}
