namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CBloomConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(24)] public float _bloomLuminanceScale = 1.0f;
        [FieldAttr(28)] public float _bloomLuminanceBias = 1.0f;
        [FieldAttr(32)] public float _bloomScale = 1.0f;
    }
}
