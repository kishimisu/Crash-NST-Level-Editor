namespace Alchemy
{
    // VSC object extracted from: common_OnStartMusic_c.igz

    [ObjectAttr(80, metaType: typeof(CVscComponentData))]
    public class common_OnStartMusicData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _OnStartMusic = new();
        [FieldAttr(48)] public float _Float_0x30;
        [FieldAttr(52)] public bool _Bool;
        [FieldAttr(56)] public igHandleMetaField _Game_Int_Variable = new();
        [FieldAttr(64)] public igHandleMetaField _Game_Sound_Music_Settings = new();
        [FieldAttr(72)] public float _Float_0x48;
    }
}
