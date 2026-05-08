namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Trigger_Music_Gem_Start_DirData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Game_Sound_Music_Settings_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Game_Sound_Music_Settings_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Game_Sound_Music_Settings_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _Float;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Game_Sound_Music_Settings_0x48 = new();
    }
}
