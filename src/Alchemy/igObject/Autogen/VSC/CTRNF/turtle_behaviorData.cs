namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class turtle_behaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Spline_Event = new();
        [FieldAttr(nst: 48, ctr: 40)] public string? _String_0x28 = null;
        [FieldAttr(nst: 56, ctr: 48)] public string? _String_0x30 = null;
    }
}
