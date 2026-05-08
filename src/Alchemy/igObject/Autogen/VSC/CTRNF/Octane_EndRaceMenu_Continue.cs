namespace Alchemy
{
    [ObjectAttr(nst: 496, ctr: 488, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_EndRaceMenu_Continue : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Gui_Animation_Tag_0x28 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Gui_Placeable_0x30 = new();
        [FieldAttr(nst: 64, ctr: 56)] public EOctaneRaceModes _E_Octane_Race_Modes_0x38;
        [FieldAttr(nst: 68, ctr: 60)] public int _InternalStore__internalCounter;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Entity_0x40 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igObject? _Entity_List = new();
        [FieldAttr(nst: 88, ctr: 80)] public int _Int;
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Zone_Info_0x58 = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Gui_Placeable_0x60 = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Gui_Animation_Tag_0x68 = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Gui_Animation_Tag_0x70 = new();
        [FieldAttr(nst: 128, ctr: 120)] public EGameMode _E_Game_Mode;
        [FieldAttr(nst: 136, ctr: 128)] public igObject? _InternalStore__gate_0x80 = new();
        [FieldAttr(nst: 144, ctr: 136)] public bool _Bool_0x88;
        [FieldAttr(nst: 152, ctr: 144)] public igObject? _InternalStore__timer = new();
        [FieldAttr(nst: 160, ctr: 152)] public igHandleMetaField _Entity_0x98 = new();
        [FieldAttr(nst: 168, ctr: 160)] public igHandleMetaField _Entity_0xa0 = new();
        [FieldAttr(nst: 176, ctr: 168)] public string? _String = null;
        [FieldAttr(nst: 184, ctr: 176)] public igHandleMetaField _Waypoint_0xb0 = new();
        [FieldAttr(nst: 192, ctr: 184)] public igObject? _Edc_Info = new();
        [FieldAttr(nst: 200, ctr: 192)] public igHandleMetaField _Sound_Instance = new();
        [FieldAttr(nst: 208, ctr: 200)] public igHandleMetaField _Zone_Info_0xc8 = new();
        [FieldAttr(nst: 216, ctr: 208)] public igObject? _Entity_Handle_List = new();
        [FieldAttr(nst: 224, ctr: 216)] public igHandleMetaField _Gui_Animation_Tag_0xd8 = new();
        [FieldAttr(nst: 232, ctr: 224)] public igHandleMetaField _Gui_Placeable_0xe0 = new();
        [FieldAttr(nst: 240, ctr: 232)] public igHandleMetaField _Waypoint_0xe8 = new();
        [FieldAttr(nst: 248, ctr: 240)] public igObject? _InternalStore_sequenceData_0xf0 = new();
        [FieldAttr(nst: 256, ctr: 248)] public igObject? _InternalStore_sequenceData_0xf8 = new();
        [FieldAttr(nst: 264, ctr: 256)] public igHandleMetaField _Fade_Sequence_Preset_Data = new();
        [FieldAttr(nst: 272, ctr: 264)] public igObject? _InternalStore__gate_0x108 = new();
        [FieldAttr(nst: 280, ctr: 272)] public igHandleMetaField _Entity_0x110 = new();
        [FieldAttr(nst: 288, ctr: 280)] public EOctaneAdventureCutscene _E_Octane_Adventure_Cutscene;
        [FieldAttr(nst: 296, ctr: 288)] public igHandleMetaField _Zone_Info_0x120 = new();
        [FieldAttr(nst: 304, ctr: 296)] public bool _Bool_0x128;
        [FieldAttr(nst: 305, ctr: 297)] public bool _Bool_0x129;
        [FieldAttr(nst: 306, ctr: 298)] public bool _Bool_0x12a;
        [FieldAttr(nst: 312, ctr: 304)] public igHandleMetaField _Entity_0x130 = new();
        [FieldAttr(nst: 320, ctr: 312)] public EOctaneRaceModes _E_Octane_Race_Modes_0x138;
        [FieldAttr(nst: 324, ctr: 316)] public bool _Bool_0x13c;
        [FieldAttr(nst: 328, ctr: 320)] public igObject? _InternalStore_prioritySetHandler_0x140 = new();
        [FieldAttr(nst: 336, ctr: 328)] public igHandleMetaField _Priority_Dsp_Override_Set_0x148 = new();
        [FieldAttr(nst: 344, ctr: 336)] public igHandleMetaField _Priority_Dsp_Override_Set_0x150 = new();
        [FieldAttr(nst: 352, ctr: 344)] public igObject? _InternalStore_prioritySetHandler_0x158 = new();
        [FieldAttr(nst: 360, ctr: 352)] public igHandleMetaField _Camera = new();
        [FieldAttr(nst: 368, ctr: 360)] public igObject? _InternalStore__gate_0x168 = new();
        [FieldAttr(nst: 376, ctr: 368)] public bool _Bool_0x170;
        [FieldAttr(nst: 377, ctr: 369)] public bool _Bool_0x171;
        [FieldAttr(nst: 384, ctr: 376)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 392, ctr: 384)] public bool _Bool_0x180;
        [FieldAttr(nst: 400, ctr: 392)] public igObject? _InternalStore_updateNodeUpdater_0x188 = new();
        [FieldAttr(nst: 408, ctr: 400)] public igObject? _InternalStore__gate_0x190 = new();
        [FieldAttr(nst: 416, ctr: 408)] public igObject? _InternalStore__gate_0x198 = new();
        [FieldAttr(nst: 424, ctr: 416)] public igObject? _InternalStore_updateNodeUpdater_0x1a0 = new();
        [FieldAttr(nst: 432, ctr: 424)] public igHandleMetaField _Audio_Fade_Data_0x1a8 = new();
        [FieldAttr(nst: 440, ctr: 432)] public igHandleMetaField _Audio_Fade_Data_0x1b0 = new();
        [FieldAttr(nst: 448, ctr: 440)] public igHandleMetaField _Gui_Placeable_0x1b8 = new();
        [FieldAttr(nst: 456, ctr: 448)] public int _1a1;
        [FieldAttr(nst: 464, ctr: 456)] public igObject? _1a2 = new();
        [FieldAttr(nst: 472, ctr: 464)] public igHandleMetaField _1a3 = new();
        [FieldAttr(nst: 480, ctr: 472)] public int _1a4;
        [FieldAttr(nst: 484, ctr: 476)] public int _1a5;
        [FieldAttr(nst: 488, ctr: 480)] public int _1a6;
        [FieldAttr(nst: 492, ctr: 484)] public int _1a7;
    }
}
