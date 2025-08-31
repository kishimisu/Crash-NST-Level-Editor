namespace Alchemy
{
    [ObjectAttr(120, 8)]
    public class igFxMaterial : igCustomMaterial
    {
        [FieldAttr(64)] public string? _fxFilename = "";
        [FieldAttr(72)] public igCachedAttrListList? _instanceAttrs;
        [FieldAttr(80)] public igHandleMetaField _effectHandle = new();
        [FieldAttr(88)] public igGraphicsMaterial? _graphicsMaterial;
        [FieldAttr(96)] public uint _procVertexFormat = 49;
        [FieldAttr(100)] public int _textureCoordCount = 1;
        [FieldAttr(104)] public u64 _globalTechniqueMask;
        [FieldAttr(112)] public igStringRefList? _filesLoaded;
    }
}
