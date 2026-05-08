namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(CVscComponentData))]
    public class fleeing_fish_behaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float_0x20;
        [FieldAttr(nst: 44, ctr: 36)] public float _Float_0x24;
        [FieldAttr(nst: 48, ctr: 40)] public bool _Bool_0x28;
        [FieldAttr(nst: 52, ctr: 44)] public float _Float_0x2c;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Entity_List = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Spline_Event_0x38 = new();
        [FieldAttr(nst: 72, ctr: 64)] public string? _String_0x40 = null;
        [FieldAttr(nst: 80, ctr: 72)] public float _Float_0x48;
        [FieldAttr(nst: 84, ctr: 76)] public bool _Bool_0x4c;
        [FieldAttr(nst: 88, ctr: 80)] public float _Float_0x50;
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Spline_Event_0x58 = new();
        [FieldAttr(nst: 104, ctr: 96)] public string? _String_0x60 = null;
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Spline_Event_0x68 = new();
        [FieldAttr(nst: 120, ctr: 112)] public string? _String_0x70 = null;
    }
}
