namespace Alchemy
{
    [ObjectAttr(56, 4)]
    public class igStencilFunctionAttr : igVisualAttribute
    {
        [FieldAttr(24)] public uint _refVal;
        [FieldAttr(28)] public EIG_GFX_STENCIL_FUNCTION _func = EIG_GFX_STENCIL_FUNCTION.ALWAYS;
        [FieldAttr(32)] public uint _writeMask = 4294967295;
        [FieldAttr(36)] public uint _readMask = 4294967295;
        [FieldAttr(40)] public EIG_GFX_STENCIL_OPERATION _stenFailOp;
        [FieldAttr(44)] public EIG_GFX_STENCIL_OPERATION _stenPassZPassOp;
        [FieldAttr(48)] public EIG_GFX_STENCIL_OPERATION _stenPassZFailOp;
    }
}
