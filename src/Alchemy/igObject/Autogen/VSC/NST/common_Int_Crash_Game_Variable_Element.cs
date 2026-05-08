namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class common_Int_Crash_Game_Variable_Element : igGuiVscBehavior
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Game_Int_Variable_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Game_Int_Variable_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Game_Int_Variable_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Game_Int_Variable_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public ECrashGame _E_Crash_Game;
    }
}
