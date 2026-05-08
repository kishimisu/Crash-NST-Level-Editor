namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 96, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Follow_Parent_Spline_Once_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Spline_Velocity_Mover = new();
        [FieldAttr(nst: 48, ctr: 40)] public string? _String_0x30 = null;
        [FieldAttr(nst: 56, ctr: 48)] public string? _String_0x38 = null;
        [FieldAttr(nst: 64, ctr: 56)] public igVec3fMetaField _Vec_3F = new();
        [FieldAttr(nst: 76, ctr: 68)] public float _Float_0x4c;
        [FieldAttr(nst: 80, ctr: 72)] public float _Float_0x50;
        [FieldAttr(nst: 84, ctr: 76)] public bool _Bool_0x54;
        [FieldAttr(nst: 85, ctr: 77)] public bool _Bool_0x55;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Spline_Attach_Behavior = new();
        [FieldAttr(nst: 96, ctr: 88)] public bool _Bool_0x60;
    }
}
