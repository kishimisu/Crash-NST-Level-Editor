namespace Alchemy
{
    [ObjectAttr(400, 8)]
    public class igDebugGeometryManager : igObject
    {
        [FieldAttr(16)] public igProcGeometryBuilder? _pgbTris;
        [FieldAttr(24)] public igProcGeometryBuilder? _pgbLines;
        [FieldAttr(32)] public igObject[] _primLists = new igObject[8];
        [FieldAttr(96)] public igDebugPrimitivePool? _primPool;
        [FieldAttr(104)] public u8 _passId;
        [FieldAttr(105)] public u8 _hudPassId;
        [FieldAttr(112)] public igObject[] _stateStream = new igObject[8];
        [FieldAttr(176)] public igObject[] _drawCall = new igObject[16];
        [FieldAttr(304)] public igSizeTypeMetaField _alphaBlending = new();
        [FieldAttr(312)] public igSizeTypeMetaField _depthTestOff = new();
        [FieldAttr(320)] public igSizeTypeMetaField _backFaceCulling = new();
        [FieldAttr(328)] public igGfxShaderConstantList? _vertexShaderConstants;
        [FieldAttr(336)] public igSizeTypeMetaField _pixelShader = new();
        [FieldAttr(344)] public igSizeTypeMetaField _vertexShader = new();
        [FieldAttr(352, false)] public igRenderer? _renderer;
        [FieldAttr(360)] public bool _active;
        [FieldAttr(364)] public int _maximumVertexCount = 131072;
        [FieldAttr(368)] public int _vertexCount;
        [FieldAttr(376, false)] public igMemoryPool? _runtimeAllocationPool;
        [FieldAttr(384)] public uint _initialPrimitivePoolSize = 256;
        [FieldAttr(392)] public igSemaphore? _lock;
    }
}
