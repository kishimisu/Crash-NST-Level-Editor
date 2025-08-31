namespace Alchemy
{
    // VSC object extracted from: Hazard_Destroy_On_Move_Complete.igz

    [ObjectAttr(88, metaType: typeof(CVscComponentData))]
    public class Hazard_Destroy_On_Move_CompleteData : CVscComponentData
    {
        [FieldAttr(40)] public bool _Bool_0x28;
        [FieldAttr(41)] public bool _Bool_0x29;
        [FieldAttr(48)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(56)] public igHandleMetaField _Sound = new();
        [FieldAttr(64)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(72)] public string? _String = null;
        [FieldAttr(80)] public float _Float;
        [FieldAttr(84)] public bool _Bool_0x54;
    }
}
