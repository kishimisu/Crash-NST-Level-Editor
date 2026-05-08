namespace Alchemy
{
    [ObjectAttr(nst: 192, ctr: 184, align: 4, metaType: typeof(CVscComponentData))]
    public class B101_PapuPapu_BossEncounterData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _BossOnThroneBoltpt = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Boss = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _BossThrone = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _BossIntroCutscene = new();
        [FieldAttr(nst: 72, ctr: 64)] public float _BossStartDelay;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _BossFightWaypoint = new();
        [FieldAttr(nst: 88, ctr: 80)] public float _Float_0x58;
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Entity_0x60 = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Entity_List = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Entity_0x78 = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 136, ctr: 128)] public float _Float_0x88;
        [FieldAttr(nst: 140, ctr: 132)] public float _Float_0x8c;
        [FieldAttr(nst: 144, ctr: 136)] public float _Float_0x90;
        [FieldAttr(nst: 148, ctr: 140)] public bool _Bool_0x94;
        [FieldAttr(nst: 152, ctr: 144)] public int _Int;
        [FieldAttr(nst: 156, ctr: 148)] public float _Float_0x9c;
        [FieldAttr(nst: 160, ctr: 152)] public float _Float_0xa0;
        [FieldAttr(nst: 164, ctr: 156)] public bool _Bool_0xa4;
        [FieldAttr(nst: 168, ctr: 160)] public igKeyboardInputDevice.ESignal _Keyboard_Input_Device_Signal;
        [FieldAttr(nst: 172, ctr: 164)] public float _Float_0xac;
        [FieldAttr(nst: 176, ctr: 168)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0xb0 = new();
        [FieldAttr(nst: 184, ctr: 176)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0xb8 = new();
    }
}
