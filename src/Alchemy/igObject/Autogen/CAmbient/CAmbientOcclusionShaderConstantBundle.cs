namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CAmbientOcclusionShaderConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(24)] public float _radius = 50.0f;
        [FieldAttr(28)] public float _invRadius = 0.02f;
        [FieldAttr(32)] public float _radiusSquared = 2500.0f;
        [FieldAttr(36)] public float _projScale = 1.0f;
        [FieldAttr(40)] public float _adjustedRadius = 50.0f;
        [FieldAttr(44)] public float _normalizeTerm = 0.000016f;
        [FieldAttr(48)] public float _scale = 1.5f;
        [FieldAttr(52)] public float _bias = 1.0f;
        [FieldAttr(56)] public float _clampedRadiusMin = 10.0f;
        [FieldAttr(60)] public float _clampedRadiusMax = 24.0f;
        [FieldAttr(64)] public bool _ambientOcclusionState = true;
    }
}
