namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class L300_Hub_HiddenDragonTriggerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public int _Int;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 56, ctr: 48)] public string? _String = null;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 72, ctr: 64)] public float _Float;
    }
}
