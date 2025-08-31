namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class igGfxShaderConstant : igNamedObject
    {
        [FieldAttr(24)] public uint _baseRegister;
        [FieldAttr(32)] public string? _parameterName = "";
        [FieldAttr(40)] public uint _elementSize = 1;
        [FieldAttr(44)] public uint _vectorWidth = 4;
        [FieldAttr(48)] public uint _elementIndex;
        [FieldAttr(52)] public uint _elementCount = 1;
        [FieldAttr(56)] public uint _reserved;
        [FieldAttr(64)] public igRawRefMetaField _cachedConstant = new();
        [FieldAttr(72)] public uint _seqId;
        [FieldAttr(80, false)] public igGfxShaderConstant? _next;
    }
}
