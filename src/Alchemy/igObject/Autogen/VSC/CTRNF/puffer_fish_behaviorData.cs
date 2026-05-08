namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class puffer_fish_behaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Sound_0x28 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Sound_0x30 = new();
    }
}
