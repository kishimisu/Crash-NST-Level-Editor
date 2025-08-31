namespace Alchemy
{
    [ObjectAttr(176, 16)]
    public class igBitmapFont : igFont
    {
        [FieldAttr(80)] public igCharMetricsList? _charMetricsList;
        [FieldAttr(88)] public igCharMetricsList? _altCharMetricsList;
        [FieldAttr(96)] public igKerningPairHashTable? _kerningPairs;
        [FieldAttr(104)] public float _kernAmount = 1.0f;
        [FieldAttr(112)] public igTextureBindAttr2? _textureBind;
        [FieldAttr(120)] public igTextureBindAttr2? _altTextureBind;
        [FieldAttr(128)] public bool _isMasksAndColor;
        [FieldAttr(132)] public float _globalKerningLeft;
        [FieldAttr(136)] public float _globalKerningRight;
        [FieldAttr(144)] public igSizeTypeMetaField _textureResource = new();
        [FieldAttr(152)] public igSizeTypeMetaField _altTextureResource = new();
        [FieldAttr(160)] public igSizeTypeMetaField _samplerResource = new();
        [FieldAttr(168)] public igSizeTypeMetaField _altSamplerResource = new();
    }
}
