namespace Alchemy
{
    [ObjectAttr(136, 8)]
    public class igVertexFormat : igObject
    {
        [FieldAttr(16)] public uint _vertexSize;
        [FieldAttr(24)] public igMemoryRef<igVertexElementMetaField> _elements = new();
        [FieldAttr(40)] public igMemoryRef<u8> _platformData = new();
        [FieldAttr(56)] public EIG_GFX_PLATFORM _platform;
        [FieldAttr(64)] public igVertexFormat? _softwareBlendedFormat;
        [FieldAttr(72)] public igVertexBlender? _blender;
        [FieldAttr(80)] public bool _dynamic;
        [FieldAttr(88)] public igVertexFormatPlatform? _platformFormat;
        [FieldAttr(96)] public igMemoryRef<igVertexStreamMetaField> _streams = new();
        [FieldAttr(112)] public uint _hashCode;
        [FieldAttr(120)] public igVertexFormat? _softwareBlendedMultistreamFormat;
        [FieldAttr(128)] public bool _enableSoftwareBlending = true;
        [FieldAttr(132)] public uint _cachedUsage;
    }
}
