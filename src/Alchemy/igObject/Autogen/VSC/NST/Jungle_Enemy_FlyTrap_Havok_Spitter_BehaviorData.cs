namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class Jungle_Enemy_FlyTrap_Havok_Spitter_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _String_0x28 = null;
        [FieldAttr(nst: 48, ctr: 40)] public string? _String_0x30 = null;
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
        [FieldAttr(nst: 60, ctr: 52)] public float _Float_0x3c;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Count = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Damage_Data = new();
    }
}
