namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class igIndexFormat : igObject
    {
        [FieldAttr(16)] public EIG_INDEX_TYPE _indexType = EIG_INDEX_TYPE.INT16;
        [FieldAttr(20)] public EIG_GFX_PLATFORM _platform;
        [FieldAttr(24)] public uint _headerSize;
        [FieldAttr(28)] public uint _alignment = 4;
        [FieldAttr(32)] public bool _hasRestartIndices;
        [FieldAttr(33)] public bool _dynamic;
    }
}
