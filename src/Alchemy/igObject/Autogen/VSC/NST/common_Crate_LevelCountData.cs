namespace Alchemy
{
    [ObjectAttr(nst: 112, ctr: 104, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Crate_LevelCountData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _addToCrateTotal;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Total = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Count = new();
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Game_Int_Variable_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Game_Int_Variable_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _BonusRoundActive = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _PlayerDied = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Game_Int_Variable_0x68 = new();
    }
}
