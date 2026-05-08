namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class Hazard_Destroy_On_Move_CompleteData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _Bool_0x28;
        [FieldAttr(nst: 41, ctr: 33)] public bool _Bool_0x29;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 72, ctr: 64)] public string? _String = null;
        [FieldAttr(nst: 80, ctr: 72)] public float _Float;
        [FieldAttr(nst: 84, ctr: 76)] public bool _Bool_0x54;
    }
}
