namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igAlphaFunctionAttr : igVisualAttribute
    {
        [FieldAttr(24)] public EIG_GFX_ALPHA_FUNCTION _func = EIG_GFX_ALPHA_FUNCTION.GEQUAL;
        [FieldAttr(28)] public float _refValue;
    }
}
