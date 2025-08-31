namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class igIndexArray2 : igBaseIndexArray
    {
        [FieldAttr(80)] public igRawRefMetaField _dxIndexBuffer = new();
        [FieldAttr(88)] public u32 /* igStructMetaField */ _dxFormat;
        [FieldAttr(92)] public bool _dirty = true;
    }
}
