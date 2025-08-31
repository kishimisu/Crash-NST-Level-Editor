namespace Alchemy
{
    [ObjectAttr(352, 16)]
    public class CVfxDecalMaterial : igFxMaterial
    {
        [ObjectAttr(1)]
        public class VfxDecalMaterialBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _textureCompression_diffuse = true;
            [FieldAttr(1, size: 1)] public bool _textureMips_diffuse = false;
            [FieldAttr(2, size: 1)] public bool _textureAllowDownsample_diffuse = false;
            [FieldAttr(3, size: 1)] public bool _useOriginalTextureName;
        }

        [FieldAttr(120)] public u8 _bfStorage__0;
        [FieldAttr(128)] public igMatrix44fMetaField _textureTransform = new();
        [FieldAttr(192)] public VfxDecalMaterialBitfield _vfxDecalMaterialBitfield = new();
        [FieldAttr(200)] public string? _textureName_diffuse = null;
        [FieldAttr(208)] public string? _textureName = null;
        [FieldAttr(224)] public igVec4fMetaField _color = new();
        [FieldAttr(240)] public bool _enableFadeAngle;
        [FieldAttr(244)] public float _fadeStartAngle = 45.0f;
        [FieldAttr(248)] public float _fadeEndAngle = 60.0f;
        [FieldAttr(256)] public igVec4fMetaField _alphaScaleOffset = new();
        [FieldAttr(272)] public bool _enableEdgeFade;
        [FieldAttr(288)] public igVec4fMetaField _edgeFadeDistances = new();
        [FieldAttr(304)] public igVec4fMetaField _edgeFadeOffset = new();
        [FieldAttr(320)] public igVec4fMetaField _edgeFadeScale = new();
        [FieldAttr(336)] public bool _showOnWater;
        [FieldAttr(337)] public bool _shadowDecal;
    }
}
