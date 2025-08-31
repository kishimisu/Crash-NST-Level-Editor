namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igMetaImage : igObject
    {
        [ObjectAttr(1)]
        public class Properties : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _isTile;
            [FieldAttr(1, size: 1)] public bool _isCanonical;
            [FieldAttr(2, size: 1)] public bool _isCompressed;
            [FieldAttr(3, size: 1)] public bool _hasPalette;
            [FieldAttr(4, size: 1)] public bool _isSrgb;
            [FieldAttr(5, size: 1)] public bool _isFloatingPoint;
        }

        [FieldAttr(16, false)] public igMetaImage? _canonical;
        [FieldAttr(24)] public Properties _properties = new();
        [FieldAttr(32)] public string? _name = null;
        [FieldAttr(40)] public u8 _bitsPerPixel;
        [FieldAttr(48)] public igNonRefCountedMetaImageList? _formats;
        [FieldAttr(56)] public igImage2ConvertFunctionList? _functions;
    }
}
