namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igTextureSamplerSource : igNamedObject
    {
        [FieldAttr(24)] public uint _textureUnit;
        [FieldAttr(28)] public uint _samplerNumber;
        [FieldAttr(32)] public uint _reserved;
    }
}
