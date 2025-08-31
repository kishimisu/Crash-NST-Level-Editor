namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class igAlphaBlendFunctionAttr : igVisualAttribute
    {
        [FieldAttr(24)] public EIG_GFX_BLENDING_FUNCTION _source = EIG_GFX_BLENDING_FUNCTION.SOURCE_ALPHA;
        [FieldAttr(28)] public EIG_GFX_BLENDING_FUNCTION _destination = EIG_GFX_BLENDING_FUNCTION.ONE_MINUS_SOURCE_ALPHA;
        [FieldAttr(32)] public EIG_GFX_BLENDING_EQUATION _equation;
    }
}
