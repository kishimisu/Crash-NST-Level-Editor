namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igDepthFunctionAttr : igVisualAttribute
    {
        [FieldAttr(24)] public EIG_GFX_DEPTH_TEST_FUNCTION _func = EIG_GFX_DEPTH_TEST_FUNCTION.LEQUAL;
    }
}
