namespace Alchemy
{
    [ObjectAttr(152, 8)]
    public class igVertexArray : igBaseVertexArray
    {
        [FieldAttr(112)] public igRawRefMetaField[] _dxVertexBuffer = new igRawRefMetaField[4];
        [FieldAttr(144)] public int _streamCount;
        [FieldAttr(148)] public bool _dirty = true;
    }
}
