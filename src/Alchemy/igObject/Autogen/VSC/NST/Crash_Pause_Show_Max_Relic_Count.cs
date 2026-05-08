namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Crash_Pause_Show_Max_Relic_Count : igGuiVscBehavior
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Game_Int_Variable_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public ECrashGame _E_Crash_Game;
        [FieldAttr(nst: 52, ctr: 44)] public int _Int;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Game_Int_Variable_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Game_Int_Variable_0x40 = new();
    }
}
