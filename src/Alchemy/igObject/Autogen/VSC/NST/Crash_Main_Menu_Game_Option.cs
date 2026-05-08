namespace Alchemy
{
    [ObjectAttr(nst: 488, ctr: 480, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Crash_Main_Menu_Game_Option : igGuiVscBehavior
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Gui_Placeable_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Gui_Placeable_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Gui_Animation_Tag_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Gui_Animation_Tag_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igObject? _InternalStore__gate_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Gui_Placeable_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Gui_Placeable_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public bool _Bool_0x60;
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _String_List = new();
        [FieldAttr(nst: 112, ctr: 104)] public string? _String_0x70 = null;
        [FieldAttr(nst: 120, ctr: 112)] public string? _String_0x78 = null;
        [FieldAttr(nst: 128, ctr: 120)] public int _Int_0x80;
        [FieldAttr(nst: 136, ctr: 128)] public string? _String_0x88 = null;
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _Gui_Placeable_0x90 = new();
        [FieldAttr(nst: 152, ctr: 144)] public int _Int_0x98;
        [FieldAttr(nst: 156, ctr: 148)] public int _Int_0x9c;
        [FieldAttr(nst: 160, ctr: 152)] public bool _Bool_0xa0;
        [FieldAttr(nst: 168, ctr: 160)] public string? _String_0xa8 = null;
        [FieldAttr(nst: 176, ctr: 168)] public igHandleMetaField _Gui_Animation_Tag_0xb0 = new();
        [FieldAttr(nst: 184, ctr: 176)] public igHandleMetaField _Gui_Animation_Tag_0xb8 = new();
        [FieldAttr(nst: 192, ctr: 184)] public bool _Bool_0xc0;
        [FieldAttr(nst: 196, ctr: 188)] public ECrashGame _E_Crash_Game;
        [FieldAttr(nst: 200, ctr: 192)] public igHandleMetaField _Gui_Animation_Category = new();
        [FieldAttr(nst: 208, ctr: 200)] public igHandleMetaField _Gui_Animation_Tag_0xd0 = new();
        [FieldAttr(nst: 216, ctr: 208)] public igHandleMetaField _Language_Animation_Tag_Table = new();
        [FieldAttr(nst: 224, ctr: 216)] public igHandleMetaField _Gui_Animation_Tag_0xe0 = new();
        [FieldAttr(nst: 232, ctr: 224)] public igHandleMetaField _Sound_Instance_0xe8 = new();
        [FieldAttr(nst: 240, ctr: 232)] public igHandleMetaField _Sound_0xf0 = new();
        [FieldAttr(nst: 248, ctr: 240)] public float _Float_0xf8;
        [FieldAttr(nst: 252, ctr: 244)] public float _Float_0xfc;
        [FieldAttr(nst: 256, ctr: 248)] public float _Float_0x100;
        [FieldAttr(nst: 260, ctr: 252)] public float _Float_0x104;
        [FieldAttr(nst: 264, ctr: 256)] public igObject? _InternalStore_updateNodeUpdater_0x108 = new();
        [FieldAttr(nst: 272, ctr: 264)] public float _Float_0x110;
        [FieldAttr(nst: 276, ctr: 268)] public float _Float_0x114;
        [FieldAttr(nst: 280, ctr: 272)] public float _Float_0x118;
        [FieldAttr(nst: 284, ctr: 276)] public float _Float_0x11c;
        [FieldAttr(nst: 288, ctr: 280)] public float _Float_0x120;
        [FieldAttr(nst: 296, ctr: 288)] public igObject? _InternalStore_updateNodeUpdater_0x128 = new();
        [FieldAttr(nst: 304, ctr: 296)] public igHandleMetaField _Entity_0x130 = new();
        [FieldAttr(nst: 312, ctr: 304)] public igObject? _InternalStore__timer_0x138 = new();
        [FieldAttr(nst: 320, ctr: 312)] public float _Float_0x140;
        [FieldAttr(nst: 328, ctr: 320)] public igHandleMetaField _Entity_0x148 = new();
        [FieldAttr(nst: 336, ctr: 328)] public bool _Bool_0x150;
        [FieldAttr(nst: 344, ctr: 336)] public igHandleMetaField _Localized_String = new();
        [FieldAttr(nst: 352, ctr: 344)] public igHandleMetaField _Sound_Instance_0x160 = new();
        [FieldAttr(nst: 360, ctr: 352)] public igHandleMetaField _Sound_0x168 = new();
        [FieldAttr(nst: 368, ctr: 360)] public igHandleMetaField _Entity_0x170 = new();
        [FieldAttr(nst: 376, ctr: 368)] public bool _Bool_0x178;
        [FieldAttr(nst: 380, ctr: 372)] public float _Float_0x17c;
        [FieldAttr(nst: 384, ctr: 376)] public igHandleMetaField _Zone_Info = new();
        [FieldAttr(nst: 392, ctr: 384)] public igObject? _InternalStore__timer_0x188 = new();
        [FieldAttr(nst: 400, ctr: 392)] public float _Float_0x190;
        [FieldAttr(nst: 408, ctr: 400)] public igObject? _InternalStore__timer_0x198 = new();
        [FieldAttr(nst: 416, ctr: 408)] public igObject? _InternalStore_queryHolder = new();
        [FieldAttr(nst: 424, ctr: 416)] public igHandleMetaField _Gui_Placeable_0x1a8 = new();
        [FieldAttr(nst: 432, ctr: 424)] public igHandleMetaField _Gui_Placeable_0x1b0 = new();
        [FieldAttr(nst: 440, ctr: 432)] public igHandleMetaField _Gui_Placeable_0x1b8 = new();
        [FieldAttr(nst: 448, ctr: 440)] public igHandleMetaField _Gui_Placeable_0x1c0 = new();
        [FieldAttr(nst: 456, ctr: 448)] public string? _String_0x1c8 = null;
        [FieldAttr(nst: 464, ctr: 456)] public string? _String_0x1d0 = null;
        [FieldAttr(nst: 472, ctr: 464)] public string? _String_0x1d8 = null;
        [FieldAttr(nst: 480, ctr: 472)] public igObject? _InternalStore__gate_0x1e0 = new();
    }
}
