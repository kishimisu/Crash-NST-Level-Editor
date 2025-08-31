namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igGraphicsEffect : igNamedObject
    {
        [FieldAttr(24)] public igIntList? _globalTechniqueList;
        [FieldAttr(32)] public u64 _globalTechniqueMask;
        [FieldAttr(40)] public igGraphicsObjectSet? _graphicsObjects;
        [FieldAttr(48)] public igStringRefList? _techniqueNames;
        [FieldAttr(56)] public igMemoryCommandStreamList? _commandStreams;
        [FieldAttr(64)] public igUnsignedIntList? _combinedTechniqueFlags;
        [FieldAttr(72)] public uint _procVertexFormat;
    }
}
