namespace Alchemy
{
    [ObjectAttr(304, 16)]
    public class CSkyboxConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(24)] public float _skyIntensity = 1.0f;
        [FieldAttr(28)] public float _sunIntensity = 10.0f;
        [FieldAttr(32)] public float _sunExponent = 2048.0f;
        [FieldAttr(48)] public igVec4fMetaField _sunDirection = new();
        [FieldAttr(64)] public igVec4fMetaField _sunColor = new();
        [FieldAttr(80)] public igVec4fMetaField _sunshaftColor = new();
        [FieldAttr(96)] public igVec4fMetaField _sunshaftOrigin = new();
        [FieldAttr(112)] public float _sunshaftFade = 1.0f;
        [FieldAttr(116)] public float _sunshaftDecay = 0.999f;
        [FieldAttr(120)] public float _sunshaftDensity = 1.0f;
        [FieldAttr(124)] public float _sunshaftIntensity = 1.0f;
        [FieldAttr(128)] public igVec4fMetaField[] _sunshaftWeights = new igVec4fMetaField[10];
        [FieldAttr(288)] public float _skyboxFade = 1.0f;
    }
}
