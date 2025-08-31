namespace Alchemy
{
    [ObjectAttr(128, 16)]
    public class igForwardLitRenderPassData : igObject
    {
        [FieldAttr(16)] public float _ambientSpecularScale = 1.0f;
        [FieldAttr(20)] public float _ambientDiffuseScale = 1.0f;
        [FieldAttr(24)] public bool _hazeState;
        [FieldAttr(28)] public float _hazeStartDepth = 0.5f;
        [FieldAttr(32)] public float _hazeSaturateDepth = 0.8f;
        [FieldAttr(36)] public float _minHaze;
        [FieldAttr(40)] public float _maxHaze = 0.8f;
        [FieldAttr(44)] public float _hazeDensity = 1.7f;
        [FieldAttr(48)] public float _fogStart;
        [FieldAttr(52)] public float _fogDensity = 0.001f;
        [FieldAttr(64)] public igVec4fMetaField _fogColor = new();
        [FieldAttr(80)] public igVec4fMetaField _fogSunColor = new();
        [FieldAttr(96)] public float _fogSunInfluence = 1.0f;
        [FieldAttr(100)] public float _fogIntensity = 1.0f;
        [FieldAttr(104)] public float _cloudCoverScale;
        [FieldAttr(108)] public float _cloudCoverTileSize = 1.0f;
        [FieldAttr(112)] public float _cloudCoverSpeed = 30.0f;
        [FieldAttr(116)] public igVec2fMetaField _cloudCoverDirection = new();
    }
}
