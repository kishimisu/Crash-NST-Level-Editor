namespace Alchemy
{
    // VSC object extracted from: Medieval_Enemy_Knight_Behavior_Component.igz

    [ObjectAttr(80, metaType: typeof(CVscComponentData))]
    public class Medieval_Enemy_Knight_SwordCollision_ComponentData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(48)] public igHandleMetaField _Entity = new();
        [FieldAttr(56)] public bool _Bool_0x38;
        [FieldAttr(57)] public bool _Bool_0x39;
        [FieldAttr(58)] public bool _Bool_0x3a;
        [FieldAttr(59)] public bool _Bool_0x3b;
        [FieldAttr(64)] public string? _String_0x40 = null;
        [FieldAttr(72)] public string? _String_0x48 = null;
    }
}
