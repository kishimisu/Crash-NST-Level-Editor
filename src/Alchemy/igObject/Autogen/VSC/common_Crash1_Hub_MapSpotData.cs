namespace Alchemy
{
    // VSC object extracted from: common_Crash1_Hub_MapSpot_c.igz

    [ObjectAttr(296, metaType: typeof(CVscComponentData))]
    public class common_Crash1_Hub_MapSpotData : CVscComponentData
    {
        public enum EInputMapDirectionRight
        {
            PreviousMap = 0,
            NextMap = 1,
            ToSecretMap = 2,
            FromSecretMap = 3,
            None = 4,
            ShortcutForward = 5,
            ShortcutBackward = 6,
        }

        public enum EInputMapDirectionUp
        {
            PreviousMap = 0,
            NextMap = 1,
            ToSecretMap = 2,
            FromSecretMap = 3,
            None = 4,
            ShortcutForward = 5,
            ShortcutBackward = 6,
        }

        public enum EInputMapDirectionLeft
        {
            PreviousMap = 0,
            NextMap = 1,
            ToSecretMap = 2,
            FromSecretMap = 3,
            None = 4,
            ShortcutForward = 5,
            ShortcutBackward = 6,
        }

        public enum EInputMapDirectionDown
        {
            PreviousMap = 0,
            NextMap = 1,
            ToSecretMap = 2,
            FromSecretMap = 3,
            None = 4,
            ShortcutForward = 5,
            ShortcutBackward = 6,
        }

        [FieldAttr(40)] public igHandleMetaField _SecretMapSpotSpline = new();
        [FieldAttr(48)] public EInputMapDirectionRight _InputMapDirectionRight;
        [FieldAttr(52)] public EInputMapDirectionUp _InputMapDirectionUp;
        [FieldAttr(56)] public EInputMapDirectionLeft _InputMapDirectionLeft;
        [FieldAttr(60)] public EInputMapDirectionDown _InputMapDirectionDown;
        [FieldAttr(64)] public igHandleMetaField _MapLoadFadeOut = new();
        [FieldAttr(72)] public igHandleMetaField _PathToUnlockMaterialOverride = new();
        [FieldAttr(80)] public igHandleMetaField _MapSpotSplineMarker = new();
        [FieldAttr(88)] public igHandleMetaField _CameraSplineMarker = new();
        [FieldAttr(96)] public igHandleMetaField _VfxMapUnlockIdleData = new();
        [FieldAttr(104)] public igHandleMetaField _MapZoneInfo = new();
        [FieldAttr(112)] public igHandleMetaField _PathTo = new();
        [FieldAttr(120)] public igHandleMetaField _Gui_Animation_Tag = new();
        [FieldAttr(128)] public igHandleMetaField _Sound = new();
        [FieldAttr(136)] public EZoneCollectibleType _E_Zone_Collectible_Type_0x88;
        [FieldAttr(140)] public bool _Bool_0x8c;
        [FieldAttr(144)] public igHandleMetaField _Zone_Info_0x90 = new();
        [FieldAttr(152)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(160)] public EZoneCollectibleType _E_Zone_Collectible_Type_0xa0;
        [FieldAttr(168)] public igHandleMetaField _Localized_String = new();
        [FieldAttr(176)] public igHandleMetaField _Game_Float_Variable = new();
        [FieldAttr(184)] public igHandleMetaField _common_C2_WarpRoom_LevelPortalDatas025 = new();
        [FieldAttr(192)] public igHandleMetaField _common_C2_WarpRoom_LevelPortalDatas023_0xc0 = new();
        [FieldAttr(200)] public igHandleMetaField _common_C2_WarpRoom_LevelPortalDatas026 = new();
        [FieldAttr(208)] public igHandleMetaField _common_C2_WarpRoom_LevelPortalDatas023_0xd0 = new();
        [FieldAttr(216)] public igHandleMetaField _common_C2_WarpRoom_LevelPortalDatas027 = new();
        [FieldAttr(224)] public igHandleMetaField _common_C2_WarpRoom_LevelPortalDatas022 = new();
        [FieldAttr(232)] public bool _Bool_0xe8;
        [FieldAttr(240)] public igHandleMetaField _Entity_0xf0 = new();
        [FieldAttr(248)] public igHandleMetaField _Entity_0xf8 = new();
        [FieldAttr(256)] public igHandleMetaField _Zone_Info_0x100 = new();
        [FieldAttr(264)] public igHandleMetaField _Entity_0x108 = new();
        [FieldAttr(272)] public igHandleMetaField _Entity_0x110 = new();
        [FieldAttr(280)] public igHandleMetaField _Entity_0x118 = new();
        [FieldAttr(288)] public igHandleMetaField _Entity_0x120 = new();
    }
}
