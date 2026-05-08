namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Crate_Switch_IronData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _OulinedCrates = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _ChangeDelay;
        [FieldAttr(nst: 52, ctr: 44)] public float _Float;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Bolt_Point = new();
    }
}
