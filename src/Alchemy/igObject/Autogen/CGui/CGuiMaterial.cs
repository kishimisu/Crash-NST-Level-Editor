namespace Alchemy
{
    [ObjectAttr(224, 16)]
    public class CGuiMaterial : igFxMaterial
    {
        [ObjectAttr(4)]
        public class Bitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _textureCompression_diffuse = true;
            [FieldAttr(1, size: 1)] public bool _textureMips_diffuse;
            [FieldAttr(2, size: 1)] public bool _textureAllowDownsample_diffuse = false;
        }

        [FieldAttr(120)] public u8 _bfStorage__0;
        [FieldAttr(124)] public Bitfield _bitfield = new();
        [FieldAttr(128)] public u8 _bfStorage__1;
        [FieldAttr(136)] public string? _textureName_diffuse = null;
        [FieldAttr(144)] public igMatrix44fMetaField _textureTransform = new();
        [FieldAttr(208)] public string? _textureName = null;
    }
}
