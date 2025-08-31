namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igVfxTranslateApplyBoltSizeOperator : igVfxOperator
    {
        [FieldAttr(24)] public EReferenceFrame _relativeTo = EReferenceFrame.eRF_Bolt1;
        [FieldAttr(28)] public EReferenceFrame _withSizeFrom = EReferenceFrame.eRF_Bolt1;
    }
}
