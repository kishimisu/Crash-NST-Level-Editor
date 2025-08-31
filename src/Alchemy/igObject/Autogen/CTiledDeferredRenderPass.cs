namespace Alchemy
{
    [ObjectAttr(912, 16)]
    public class CTiledDeferredRenderPass : igSceneRenderPass
    {
        [FieldAttr(464)] public igHandleMetaField _pointLights = new();
        [FieldAttr(472)] public igHandleMetaField _boxLights = new();
        [FieldAttr(480)] public igVec4fMetaField _nearPlane = new();
        [FieldAttr(496)] public igVec4fMetaField _farPlane = new();
        [FieldAttr(512)] public igVectorMetaField<igVec4fMetaField> _horizontalPlanes = new();
        [FieldAttr(536)] public igVectorMetaField<igVec4fMetaField> _verticalPlanes = new();
        [FieldAttr(560)] public igHandleMetaField _materialHandle = new();
        [FieldAttr(568)] public igVectorMetaField<igVec4fMetaField> _pointLightPositions = new();
        [FieldAttr(592)] public igVectorMetaField<igVec4fMetaField> _pointLightColors = new();
        [FieldAttr(616)] public igVectorMetaField<igVec4fMetaField> _pointLightParameters = new();
        [FieldAttr(640)] public igVectorMetaField<igMatrix44fMetaField> _boxLightMatrices = new();
        [FieldAttr(664)] public igVectorMetaField<igVec4fMetaField> _boxLightDirections = new();
        [FieldAttr(688)] public igVectorMetaField<igVec4fMetaField> _boxLightColors = new();
        [FieldAttr(712)] public igVectorMetaField<igVec4fMetaField> _boxLightParameters = new();
        [FieldAttr(736)] public igVectorMetaField<igMatrix44fMetaField> _boxUvTransforms = new();
        [FieldAttr(760)] public igObject[] _globalLightRigs = new igObject[2];
        [FieldAttr(776)] public int _curLightLists;
        [FieldAttr(780)] public int _tileSizeX = 64;
        [FieldAttr(784)] public int _tileSizeY = 64;
        [FieldAttr(788)] public int _numTilesX = -1;
        [FieldAttr(792)] public int _numTilesY = -1;
        [FieldAttr(800)] public CTileDeferredRenderPassDebugData? _debuggingData;
        [FieldAttr(808)] public float _cachedFov = -1.0f;
        [FieldAttr(812)] public float _cachedNear = -1.0f;
        [FieldAttr(816)] public float _cachedFar = -1.0f;
        [FieldAttr(824)] public igHandleMetaField _sunLightHandle = new();
        [FieldAttr(832)] public igHandleMetaField _renderData = new();
        [FieldAttr(840)] public igOutdoorLightConstantBundle? _outdoorLightConstantBundle;
        [FieldAttr(848)] public igAtmosphericsConstantBundle? _atmosphericsConstantBundle;
        [FieldAttr(856)] public CLocalShadowInfluenceConstantBundle? _localShadowInfluenceConstantBundle;
        [FieldAttr(864)] public igSizeTypeMetaField _vertexBuffer = new();
        [FieldAttr(872)] public igSizeTypeMetaField _vertexFormatResource = new();
        [FieldAttr(880)] public igDynamicBuffer? _indexBuffer;
        [FieldAttr(888)] public igVertexFormat? _vertexFormat;
        [FieldAttr(896)] public CTileDeferredRenderPassDrawCallPool? _drawCallPool;
        [FieldAttr(904)] public int _version = 1;
    }
}
