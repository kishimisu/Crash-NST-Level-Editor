namespace Alchemy
{
    // VSC object extracted from: common_Entity_Remove_On_Attack_Attempt.igz

    [ObjectAttr(128, metaType: typeof(CVscComponentData))]
    public class common_Entity_Remove_On_Attack_AttemptData : CVscComponentData
    {
        [FieldAttr(40)] public string? _String_0x28 = null;
        [FieldAttr(48)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data = new();
        [FieldAttr(56)] public bool _Bool_0x38;
        [FieldAttr(64)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(72)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(80)] public bool _Bool_0x50;
        [FieldAttr(88)] public igHandleMetaField _Sound = new();
        [FieldAttr(96)] public string? _String_0x60 = null;
        [FieldAttr(104)] public bool _Bool_0x68;
        [FieldAttr(108)] public float _Float_0x6c;
        [FieldAttr(112)] public float _Float_0x70;
        [FieldAttr(116)] public float _Float_0x74;
        [FieldAttr(120)] public float _Float_0x78;
    }
}
