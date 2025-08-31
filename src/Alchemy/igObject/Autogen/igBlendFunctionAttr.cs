namespace Alchemy
{
    [ObjectAttr(64, 4)]
    public class igBlendFunctionAttr : igVisualAttribute
    {
        [FieldAttr(24)] public EIG_GFX_BLENDING_FUNCTION _src = EIG_GFX_BLENDING_FUNCTION.SOURCE_ALPHA;
        [FieldAttr(28)] public EIG_GFX_BLENDING_FUNCTION _dst = EIG_GFX_BLENDING_FUNCTION.ONE_MINUS_SOURCE_ALPHA;
        [FieldAttr(32)] public EIG_GFX_BLENDING_EQUATION _eq;
        [FieldAttr(36)] public uint _unused;
        [FieldAttr(40)] public u8 _blendConstant;
        [FieldAttr(42)] public i16 _blendStage;
        [FieldAttr(44)] public uint _blendA;
        [FieldAttr(48)] public uint _blendB;
        [FieldAttr(52)] public uint _blendC;
        [FieldAttr(56)] public uint _blendD;
    }
}
