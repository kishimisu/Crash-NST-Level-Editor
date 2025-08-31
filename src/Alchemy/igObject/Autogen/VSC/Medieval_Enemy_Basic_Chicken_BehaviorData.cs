namespace Alchemy
{
    // VSC object extracted from: Medieval_Enemy_Basic_Chicken_Behavior.igz

    [ObjectAttr(96, metaType: typeof(CVscComponentData))]
    public class Medieval_Enemy_Basic_Chicken_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public float _Float_0x28;
        [FieldAttr(44)] public float _Float_0x2c;
        [FieldAttr(48)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(56)] public string? _String_0x38 = null;
        [FieldAttr(64)] public string? _String_0x40 = null;
        [FieldAttr(72)] public float _Float_0x48;
        [FieldAttr(76)] public float _Float_0x4c;
        [FieldAttr(80)] public string? _String_0x50 = null;
        [FieldAttr(88)] public igHandleMetaField _Sound = new();
    }
}
