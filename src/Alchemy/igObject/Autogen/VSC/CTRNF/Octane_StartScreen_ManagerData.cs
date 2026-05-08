namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class Octane_StartScreen_ManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Game_Sound_Music_Settings_0x30 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Game_Sound_Music_Settings_0x38 = new();
    }
}
