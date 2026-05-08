namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class C1_Complex_Orbit_ControllerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float;
        [FieldAttr(nst: 48, ctr: 40)] public string? _String = null;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool;
    }
}
