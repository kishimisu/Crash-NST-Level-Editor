namespace Alchemy
{
    // VSC object extracted from: Enemy_Bolt_On_Hazard.igz

    [ObjectAttr(80, metaType: typeof(CVscComponentData))]
    public class Enemy_Bolt_On_HazardData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Entity = new();
        [FieldAttr(48)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(56)] public string? _String_0x38 = null;
        [FieldAttr(64)] public string? _String_0x40 = null;
        [FieldAttr(72)] public bool _Bool_0x48;
        [FieldAttr(73)] public bool _Bool_0x49;
        [FieldAttr(74)] public bool _Bool_0x4a;
        [FieldAttr(75)] public bool _Bool_0x4b;
    }
}
