namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class common_OnStartMusicData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _OnStartMusic = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x30;
        [FieldAttr(nst: 52, ctr: 44)] public bool _Bool;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Game_Int_Variable = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Game_Sound_Music_Settings = new();
        [FieldAttr(nst: 72, ctr: 64)] public float _Float_0x48;
    }
}
