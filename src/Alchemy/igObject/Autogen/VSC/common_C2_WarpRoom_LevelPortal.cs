namespace Alchemy
{
    // VSC object extracted from: common_C2_WarpRoom_LevelPortal.igz

    [ObjectAttr(616, metaType: typeof(CVscComponentData))]
    public class common_C2_WarpRoom_LevelPortal : CVscComponentData
    {
        [FieldAttr(40)] public string? _BehaviorEventCrashTeleportOutStart = null;
        [FieldAttr(48)] public igHandleMetaField _Bolt_Point_0x30 = new();
        [FieldAttr(56)] public igHandleMetaField _VfxTeleporterData = new();
        [FieldAttr(64)] public igHandleMetaField _Zone_Info = new();
        [FieldAttr(72)] public igHandleMetaField _MapLoadFadeOut = new();
        [FieldAttr(80)] public igHandleMetaField _Game_Bool_Variable_0x50 = new();
        [FieldAttr(88)] public float _Float;
        [FieldAttr(96)] public igHandleMetaField _Camera_Base = new();
        [FieldAttr(104)] public igHandleMetaField _Game_Bool_Variable_0x68 = new();
        [FieldAttr(112)] public igHandleMetaField _Game_Int_Variable_0x70 = new();
        [FieldAttr(120)] public bool _Bool_0x78;
        [FieldAttr(128)] public igHandleMetaField _Game_Int_Variable_0x80 = new();
        [FieldAttr(136)] public igHandleMetaField _EntityVariable_id_zoprd840_variable = new();
        [FieldAttr(144)] public igHandleMetaField _EntityVariable_id_vaqwpfm9_variable = new();
        [FieldAttr(152)] public igHandleMetaField _EntityVariable_id_e6895udv_variable = new();
        [FieldAttr(160)] public igHandleMetaField _EntityVariable_id_gjseleuy_variable = new();
        [FieldAttr(168)] public igHandleMetaField _EntityVariable_id_zmudf2jn_variable = new();
        [FieldAttr(176)] public igHandleMetaField _EntityVariable_id_s785rv7r_variable = new();
        [FieldAttr(184)] public igHandleMetaField _Entity_0xb8 = new();
        [FieldAttr(192)] public igHandleMetaField _Bolt_Point_0xc0 = new();
        [FieldAttr(200)] public igHandleMetaField _Bolt_Point_0xc8 = new();
        [FieldAttr(208)] public igHandleMetaField _Bolt_Point_0xd0 = new();
        [FieldAttr(216)] public igHandleMetaField _Entity_0xd8 = new();
        [FieldAttr(224)] public igHandleMetaField _Fade_Sequence_Preset_Data = new();
        [FieldAttr(232)] public igHandleMetaField _Vfx_Effect_0xe8 = new();
        [FieldAttr(240)] public igHandleMetaField _Vfx_Effect_0xf0 = new();
        [FieldAttr(248)] public igHandleMetaField _Vfx_Effect_0xf8 = new();
        [FieldAttr(256)] public igHandleMetaField _Vfx_Effect_0x100 = new();
        [FieldAttr(264)] public igHandleMetaField _Vfx_Effect_0x108 = new();
        [FieldAttr(272)] public igHandleMetaField _Vfx_Effect_0x110 = new();
        [FieldAttr(280)] public igHandleMetaField _Vfx_Effect_0x118 = new();
        [FieldAttr(288)] public igHandleMetaField _Vfx_Effect_0x120 = new();
        [FieldAttr(296)] public igHandleMetaField _GemExplode = new();
        [FieldAttr(304)] public bool _Bool_0x130;
        [FieldAttr(312)] public igHandleMetaField _Vfx_Effect_0x138 = new();
        [FieldAttr(320)] public igHandleMetaField _EntityVariable_id_7yddjqfs_variable = new();
        [FieldAttr(328)] public igHandleMetaField _EntityVariable_id_h33dji5b_variable = new();
        [FieldAttr(336)] public igHandleMetaField _Entity_0x150 = new();
        [FieldAttr(344)] public igHandleMetaField _Bolt_Point_0x158 = new();
        [FieldAttr(352)] public igHandleMetaField _Vfx_Effect_0x160 = new();
        [FieldAttr(360)] public igHandleMetaField _Vfx_Effect_0x168 = new();
        [FieldAttr(368)] public igHandleMetaField _Vfx_Effect_0x170 = new();
        [FieldAttr(376)] public igHandleMetaField _HandBolt_0x178 = new();
        [FieldAttr(384)] public igHandleMetaField _HandBolt_0x180 = new();
        [FieldAttr(392)] public igHandleMetaField _Bolt_Point_0x188 = new();
        [FieldAttr(400)] public EZoneCollectibleType _E_Zone_Collectible_Type;
        [FieldAttr(408)] public igHandleMetaField _Fx_Material_Redirect_Table_0x198 = new();
        [FieldAttr(416)] public igHandleMetaField _Fx_Material_Redirect_Table_0x1a0 = new();
        [FieldAttr(424)] public igHandleMetaField _Fx_Material_Redirect_Table_0x1a8 = new();
        [FieldAttr(432)] public igHandleMetaField _Fx_Material_Redirect_Table_0x1b0 = new();
        [FieldAttr(440)] public igHandleMetaField _Fx_Material_Redirect_Table_0x1b8 = new();
        [FieldAttr(448)] public igHandleMetaField _Fx_Material_Redirect_Table_0x1c0 = new();
        [FieldAttr(456)] public igHandleMetaField _Fx_Material_Redirect_Table_0x1c8 = new();
        [FieldAttr(464)] public igHandleMetaField _Game_Bool_Variable_0x1d0 = new();
        [FieldAttr(472)] public igHandleMetaField _Game_Bool_Variable_0x1d8 = new();
        [FieldAttr(480)] public igHandleMetaField _Game_Bool_Variable_0x1e0 = new();
        [FieldAttr(488)] public igHandleMetaField _Game_Bool_Variable_0x1e8 = new();
        [FieldAttr(496)] public igHandleMetaField _Game_Bool_Variable_0x1f0 = new();
        [FieldAttr(504)] public igHandleMetaField _Bolt_Point_0x1f8 = new();
        [FieldAttr(512)] public string? _String_0x200 = null;
        [FieldAttr(520)] public igVec3fMetaField _Vec_3F_0x208 = new();
        [FieldAttr(536)] public string? _GemTossClip = null;
        [FieldAttr(544)] public string? _String_0x220 = null;
        [FieldAttr(552)] public string? _String_0x228 = null;
        [FieldAttr(560)] public igHandleMetaField _HandBolt_0x230 = new();
        [FieldAttr(568)] public igHandleMetaField _Vfx_Effect_0x238 = new();
        [FieldAttr(576)] public igHandleMetaField _Vfx_Effect_0x240 = new();
        [FieldAttr(584)] public igHandleMetaField _Game_Int_Variable_0x248 = new();
        [FieldAttr(592)] public ECrashSecretZones _E_Crash_Secret_Zones;
        [FieldAttr(596)] public igVec3fMetaField _Vec_3F_0x254 = new();
        [FieldAttr(608)] public igHandleMetaField _Game_Int_Variable_0x260 = new();
    }
}
