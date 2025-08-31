namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igNode : igNamedObject
    {
        [FieldAttr(24)] public igVolume? _bound;
        [FieldAttr(32)] public igNonRefCountedNodeList? _parentList;
        [FieldAttr(40)] public i16 _traversalWeight = -1;
        [FieldAttr(42)] public i16 _traversalSpuWeight = -1;
        [FieldAttr(44)] public int _handle = -1;
        [FieldAttr(48)] public int _flags;
    }
}
