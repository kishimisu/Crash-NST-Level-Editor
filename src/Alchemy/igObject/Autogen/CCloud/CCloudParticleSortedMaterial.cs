namespace Alchemy
{
    [ObjectAttr(208, 16)]
    public class CCloudParticleSortedMaterial : igFxMaterial
    {
        [ObjectAttr(4)]
        public class TextureBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _textureCompression_diffuse = true;
            [FieldAttr(1, size: 1)] public bool _textureMips_diffuse = false;
            [FieldAttr(2, size: 1)] public bool _textureAllowDownsample_diffuse = false;
        }

        [FieldAttr(120)] public TextureBitfield _textureBitfield = new();
        [FieldAttr(128)] public string? _textureName_diffuse = null;
        [FieldAttr(144)] public igVec4fMetaField _color = new();
        [FieldAttr(160)] public igVec4fMetaField _rotationParams = new();
        [FieldAttr(176)] public float _minRotationSpeed;
        [FieldAttr(180)] public float _maxRotationSpeed;
        [FieldAttr(184)] public float _particleSoftness = 100.0f;
        [FieldAttr(188)] public float _particleSoftnessInverse;
        [FieldAttr(192)] public bool _softParticle;
    }
}
