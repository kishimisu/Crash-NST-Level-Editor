namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class Tech_Enemy_Robot_SpikedShell_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float_0x28;
        [FieldAttr(nst: 44, ctr: 36)] public float _Float_0x2c;
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x30;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public bool _Bool_0x48;
        [FieldAttr(nst: 73, ctr: 65)] public bool _Bool_0x49;
    }
}
