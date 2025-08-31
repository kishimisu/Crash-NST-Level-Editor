namespace Alchemy
{
    [ObjectAttr(144, 16)]
    public class igAtmosphericsConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(24)] public float _fogDensity = 0.001f;
        [FieldAttr(28)] public float _fogStart;
        [FieldAttr(32)] public float _fogDistanceScale = 1.0f;
        [FieldAttr(36)] public float _fogIntensity = 1.0f;
        [FieldAttr(40)] public float _fogSunScale = 0.5f;
        [FieldAttr(44)] public float _fogSunBias = 0.5f;
        [FieldAttr(48)] public float _fogSunInfluence = 1.0f;
        [FieldAttr(64)] public igVec4fMetaField _fogColor = new();
        [FieldAttr(80)] public igVec4fMetaField _fogSunDirection = new();
        [FieldAttr(96)] public igVec4fMetaField _fogSunColor = new();
        [FieldAttr(112)] public float _cloudCoverScale;
        [FieldAttr(128)] public igVec4fMetaField _cloudCoverOffset = new();
    }
}
