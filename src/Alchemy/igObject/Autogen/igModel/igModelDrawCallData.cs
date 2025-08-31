namespace Alchemy
{
    [ObjectAttr(160, 16)]
    public class igModelDrawCallData : igNamedObject
    {
        [ObjectAttr(4)]
        public class PropertiesBitField : igBitFieldMetaField
        {
            [FieldAttr(0, size: 3)] public EIG_INDEX_TYPE _indexBufferType = EIG_INDEX_TYPE.INT32;
            [FieldAttr(3, size: 3)] public EIG_GFX_DRAW _primitiveType = EIG_GFX_DRAW.POINTS;
            [FieldAttr(6, size: 8)] public u8 _lod = 3;
            [FieldAttr(14, size: 1)] public bool _enabled = false;
            [FieldAttr(15, size: 8)] public u8 _instanceShaderConstants;
        }

        [FieldAttr(32)] public igVec4fMetaField _min = new();
        [FieldAttr(48)] public igVec4fMetaField _max = new();
        [FieldAttr(64)] public igHandleMetaField _materialHandle = new();
        [FieldAttr(72)] public igGraphicsVertexBuffer? _graphicsVertexBuffer;
        [FieldAttr(80)] public igGraphicsIndexBuffer? _graphicsIndexBuffer;
        [FieldAttr(88)] public igObject? _platformData;
        [FieldAttr(96)] public u16 _blendVectorOffset;
        [FieldAttr(98)] public u16 _blendVectorCount;
        [FieldAttr(100)] public int _morphWeightTransformIndex;
        [FieldAttr(104)] public int _primitiveCount;
        [FieldAttr(108)] public PropertiesBitField _propertiesBitField = new();
        [FieldAttr(112)] public igShaderConstantBundleList? _shaderConstantBundles;
        [FieldAttr(120)] public int _bakedBufferOffset = -1;
        [FieldAttr(124)] public uint _hash;
        [FieldAttr(128)] public igSizeTypeMetaField _vertexBufferResource = new();
        [FieldAttr(136)] public igSizeTypeMetaField _vertexBufferFormatResource = new();
        [FieldAttr(144)] public igSizeTypeMetaField _indexBufferResource = new();
    }
}
