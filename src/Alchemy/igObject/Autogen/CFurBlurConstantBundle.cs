namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CFurBlurConstantBundle : igShaderConstantBundle
    {
        [FieldAttr(24)] public bool _furBlurState = true;
    }
}
