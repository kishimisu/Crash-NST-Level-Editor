namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igVfxFrameOperator : igVfxOperator
    {
        [FieldAttr(24)] public EReferenceFrame _frame = EReferenceFrame.eRF_Instance;
    }
}
