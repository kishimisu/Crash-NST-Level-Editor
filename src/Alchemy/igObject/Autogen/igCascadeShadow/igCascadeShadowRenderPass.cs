namespace Alchemy
{
    [ObjectAttr(1280, 16)]
    public class igCascadeShadowRenderPass : igSceneRenderPass
    {
        [FieldAttr(464)] public igHandleMetaField _light = new();
        [FieldAttr(472)] public igHandleMetaField _params = new();
        [FieldAttr(480)] public int _shadowMapSize = -1;
        [FieldAttr(484)] public int _numSplits = -1;
        [FieldAttr(488)] public igCascadeShadowParametersBundle? _shadowParameters;
        [FieldAttr(496)] public igMatrix44fMetaField _lightViewMatrix = new();
        [FieldAttr(560)] public igMatrix44fMetaField[] _splitProjectionMatrices = new igMatrix44fMetaField[4];
        [FieldAttr(816)] public igVec4fMetaField[] _splitBoundsMin = new igVec4fMetaField[4];
        [FieldAttr(880)] public igVec4fMetaField[] _splitBoundsMax = new igVec4fMetaField[4];
        [FieldAttr(944)] public igVec4fMetaField[] _frustumCorners = new igVec4fMetaField[8];
        [FieldAttr(1072)] public igRenderCameraList? _splitCameras;
        [FieldAttr(1080)] public igObject[] _frustumPlanes = new igObject[10];
        [FieldAttr(1160)] public igRay? _ray;
        [FieldAttr(1168)] public igRawRefMetaField _pixelShaderBinary = new();
        [FieldAttr(1176)] public int _pixelShaderBinarySize;
        [FieldAttr(1184)] public string? _pixelShaderStates = null;
        [FieldAttr(1192)] public igRawRefMetaField _vertexShaderBinary = new();
        [FieldAttr(1200)] public int _vertexShaderBinarySize;
        [FieldAttr(1208)] public string? _vertexShaderStates = null;
        [FieldAttr(1216)] public igObject[] _splitPassState = new igObject[4];
        [FieldAttr(1248)] public string?[] _splitCameraName = new string?[4];
    }
}
