namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 96, align: 8)]
    public class CStreamingMovie : igObject
    {
        [FieldAttr(nst: 16, ctr: 12)] public int _id;
        [FieldAttr(nst: 24, ctr: 16)] public string? _url = null;
        [FieldAttr(nst: 32, ctr: 24)] public igSizeTypeMetaField[] _textureY = new igSizeTypeMetaField[2];
        [FieldAttr(nst: 48, ctr: 40)] public igSizeTypeMetaField[] _textureCbCr = new igSizeTypeMetaField[2];
        [FieldAttr(nst: 64, ctr: 56)] public igImage2[] _imageY = new igImage2[2];
        [FieldAttr(nst: 80, ctr: 72)] public igImage2[] _imageCbCr = new igImage2[2];
        [FieldAttr(nst: 96, ctr: 88)] public bool _ready;
        [FieldAttr(nst: 100, ctr: 92)] public uint _lock = new();
    }
}
