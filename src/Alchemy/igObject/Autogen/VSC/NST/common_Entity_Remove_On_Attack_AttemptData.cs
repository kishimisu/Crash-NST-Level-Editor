namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Entity_Remove_On_Attack_AttemptData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _String_0x28 = null;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data = new();
        [FieldAttr(nst: 56, ctr: 48)] public bool _Bool_0x38;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 80, ctr: 72)] public bool _Bool_0x50;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 96, ctr: 88)] public string? _String_0x60 = null;
        [FieldAttr(nst: 104, ctr: 96)] public bool _Bool_0x68;
        [FieldAttr(nst: 108, ctr: 100)] public float _Float_0x6c;
        [FieldAttr(nst: 112, ctr: 104)] public float _Float_0x70;
        [FieldAttr(nst: 116, ctr: 108)] public float _Float_0x74;
        [FieldAttr(nst: 120, ctr: 112)] public float _Float_0x78;
    }
}
