namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class L300_Hub_LevelManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Fade_Sequence_Preset_Data_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Fade_Sequence_Preset_Data_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Game_Sound_Music_Settings_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Game_Sound_Music_Settings_0x40 = new();
    }
}
