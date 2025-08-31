namespace Alchemy
{
    [ObjectAttr(136, 8)]
    public class CVfxDrawVisualDataOperator : igVfxDrawOperator
    {
        [FieldAttr(32)] public CVisualDataGroup? _visualData;
        [FieldAttr(40)] public igVfxRangedCurveMetaField _influence = new();
        [FieldAttr(124)] public EOperatorCurveInput _influenceInput;
        [FieldAttr(128)] public u32 /* igStructMetaField */ _instanceData;
    }
}
