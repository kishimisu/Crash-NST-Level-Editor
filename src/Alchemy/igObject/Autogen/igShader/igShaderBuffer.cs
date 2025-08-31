namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igShaderBuffer : igObject
    {
        [FieldAttr(16)] public EIG_GFX_PLATFORM _platform;
        [FieldAttr(20)] public EIG_GFX_SHADER_TYPE _shaderType;
        [FieldAttr(24)] public uint _hash;
        [FieldAttr(32)] public igShaderHeader? _header;
        [FieldAttr(40)] public igMemoryRef<u8> _shaderData = new();
    }
}
