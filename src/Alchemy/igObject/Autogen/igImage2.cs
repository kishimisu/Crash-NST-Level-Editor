namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class igImage2 : igNamedObject
    {
        [FieldAttr(24)] public u16 _width;
        [FieldAttr(26)] public u16 _height;
        [FieldAttr(28)] public u16 _depth;
        [FieldAttr(30)] public u16 _levelCount;
        [FieldAttr(32)] public u16 _imageCount;
        [FieldAttr(40)] public igMetaImage? _format;
        [FieldAttr(48)] public uint _bitfield;
        [FieldAttr(52)] public uint _userFlags;
        [FieldAttr(56)] public igMemoryRef<u8> _data = new();
        [FieldAttr(72)] public int _texHandle = -1;
        [FieldAttr(80)] public igObject? _graphicsHelper;
    }
}
