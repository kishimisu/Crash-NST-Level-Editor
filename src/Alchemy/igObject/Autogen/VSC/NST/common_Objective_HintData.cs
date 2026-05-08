namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Objective_HintData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float_0x28;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Localized_String = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
    }
}
