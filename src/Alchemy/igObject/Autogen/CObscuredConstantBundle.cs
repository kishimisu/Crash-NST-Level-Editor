namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CObscuredConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(24)] public float _obscuredFade = 0.5f;
    }
}
