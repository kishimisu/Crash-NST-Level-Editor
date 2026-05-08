namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class Crash_Adjust_Position_OnDeathData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igVec3fMetaField _Vec_3F = new();
        [FieldAttr(nst: 52, ctr: 44)] public float _Float;
        [FieldAttr(nst: 56, ctr: 48)] public string? _String = null;
    }
}
