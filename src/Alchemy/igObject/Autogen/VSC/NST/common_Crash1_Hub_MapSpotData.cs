namespace Alchemy
{
    [ObjectAttr(nst: 296, ctr: 288, align: 4, metaType: typeof(CVscComponentData))]
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

        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _SecretMapSpotSpline = new();
        [FieldAttr(nst: 48, ctr: 40)] public EInputMapDirectionRight _InputMapDirectionRight;
        [FieldAttr(nst: 52, ctr: 44)] public EInputMapDirectionUp _InputMapDirectionUp;
        [FieldAttr(nst: 56, ctr: 48)] public EInputMapDirectionLeft _InputMapDirectionLeft;
        [FieldAttr(nst: 60, ctr: 52)] public EInputMapDirectionDown _InputMapDirectionDown;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _MapLoadFadeOut = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _PathToUnlockMaterialOverride = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _MapSpotSplineMarker = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _CameraSplineMarker = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _VfxMapUnlockIdleData = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _MapZoneInfo = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _PathTo = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Gui_Animation_Tag = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 136, ctr: 128)] public EZoneCollectibleType _E_Zone_Collectible_Type_0x88;
        [FieldAttr(nst: 140, ctr: 132)] public bool _Bool_0x8c;
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _Zone_Info_0x90 = new();
        [FieldAttr(nst: 152, ctr: 144)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 160, ctr: 152)] public EZoneCollectibleType _E_Zone_Collectible_Type_0xa0;
        [FieldAttr(nst: 168, ctr: 160)] public igHandleMetaField _Localized_String = new();
        [FieldAttr(nst: 176, ctr: 168)] public igHandleMetaField _Game_Float_Variable = new();
        [FieldAttr(nst: 184, ctr: 176)] public igHandleMetaField _common_C2_WarpRoom_LevelPortalDatas025 = new();
        [FieldAttr(nst: 192, ctr: 184)] public igHandleMetaField _common_C2_WarpRoom_LevelPortalDatas023_0xc0 = new();
        [FieldAttr(nst: 200, ctr: 192)] public igHandleMetaField _common_C2_WarpRoom_LevelPortalDatas026 = new();
        [FieldAttr(nst: 208, ctr: 200)] public igHandleMetaField _common_C2_WarpRoom_LevelPortalDatas023_0xd0 = new();
        [FieldAttr(nst: 216, ctr: 208)] public igHandleMetaField _common_C2_WarpRoom_LevelPortalDatas027 = new();
        [FieldAttr(nst: 224, ctr: 216)] public igHandleMetaField _common_C2_WarpRoom_LevelPortalDatas022 = new();
        [FieldAttr(nst: 232, ctr: 224)] public bool _Bool_0xe8;
        [FieldAttr(nst: 240, ctr: 232)] public igHandleMetaField _Entity_0xf0 = new();
        [FieldAttr(nst: 248, ctr: 240)] public igHandleMetaField _Entity_0xf8 = new();
        [FieldAttr(nst: 256, ctr: 248)] public igHandleMetaField _Zone_Info_0x100 = new();
        [FieldAttr(nst: 264, ctr: 256)] public igHandleMetaField _Entity_0x108 = new();
        [FieldAttr(nst: 272, ctr: 264)] public igHandleMetaField _Entity_0x110 = new();
        [FieldAttr(nst: 280, ctr: 272)] public igHandleMetaField _Entity_0x118 = new();
        [FieldAttr(nst: 288, ctr: 280)] public igHandleMetaField _Entity_0x120 = new();
    }
}
