namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class CrashBandicoot_JumpFlipData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _JumpStateGroup_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _JumpStateGroup_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Behavior_State_Group = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _Float_0x40;
        [FieldAttr(nst: 68, ctr: 60)] public float _Float_0x44;
    }
}
