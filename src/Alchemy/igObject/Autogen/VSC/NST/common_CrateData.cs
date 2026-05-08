namespace Alchemy
{
    [ObjectAttr(nst: 416, ctr: 408, align: 4, metaType: typeof(CVscComponentData))]
    public class common_CrateData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _AddToStreak;
        [FieldAttr(nst: 41, ctr: 33)] public bool _CanBeDestroyed;
        [FieldAttr(nst: 42, ctr: 34)] public bool _CameraFollow;
        [FieldAttr(nst: 43, ctr: 35)] public bool _IsAkuAkuCrate;
        [FieldAttr(nst: 44, ctr: 36)] public bool _AkuAku_Bounces;
        [FieldAttr(nst: 45, ctr: 37)] public bool _BouncesPlayer;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _BounceDamage = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Crate = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Special = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Chaser = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _IronCrate = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _AwarenessEntity = new();
        [FieldAttr(nst: 96, ctr: 88)] public float _AkuAkuDamageDelay;
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _AkuAkuIlluminated = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _AkuAkuInvinciblityActive = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _IsTouching = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _HavokConstraint = new();
        [FieldAttr(nst: 136, ctr: 128)] public int _BounceCount;
        [FieldAttr(nst: 140, ctr: 132)] public igVec3fMetaField _IronArrowHighHeight = new();
        [FieldAttr(nst: 152, ctr: 144)] public igVec3fMetaField _ArrowHeight = new();
        [FieldAttr(nst: 164, ctr: 156)] public igVec3fMetaField _IronArrowHeight = new();
        [FieldAttr(nst: 176, ctr: 168)] public bool _Bool_0xb0;
        [FieldAttr(nst: 184, ctr: 176)] public igHandleMetaField _Game_Bool_Variable_0xb8 = new();
        [FieldAttr(nst: 192, ctr: 184)] public bool _Bool_0xc0;
        [FieldAttr(nst: 200, ctr: 192)] public igHandleMetaField _Entity_Tag_0xc8 = new();
        [FieldAttr(nst: 208, ctr: 200)] public igHandleMetaField _Entity_0xd0 = new();
        [FieldAttr(nst: 216, ctr: 208)] public bool _Bool_0xd8;
        [FieldAttr(nst: 224, ctr: 216)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0xe0 = new();
        [FieldAttr(nst: 232, ctr: 224)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0xe8 = new();
        [FieldAttr(nst: 240, ctr: 232)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0xf0 = new();
        [FieldAttr(nst: 248, ctr: 240)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0xf8 = new();
        [FieldAttr(nst: 256, ctr: 248)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0x100 = new();
        [FieldAttr(nst: 264, ctr: 256)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0x108 = new();
        [FieldAttr(nst: 272, ctr: 264)] public igHandleMetaField _Sound_0x110 = new();
        [FieldAttr(nst: 280, ctr: 272)] public igVec3fMetaField _Vec_3F = new();
        [FieldAttr(nst: 296, ctr: 288)] public igHandleMetaField _Sound_0x128 = new();
        [FieldAttr(nst: 304, ctr: 296)] public igHandleMetaField _Entity_Tag_0x130 = new();
        [FieldAttr(nst: 312, ctr: 304)] public bool _Bool_0x138;
        [FieldAttr(nst: 313, ctr: 305)] public bool _Bool_0x139;
        [FieldAttr(nst: 320, ctr: 312)] public igHandleMetaField _Entity_Tag_0x140 = new();
        [FieldAttr(nst: 328, ctr: 320)] public igHandleMetaField _Entity_Tag_0x148 = new();
        [FieldAttr(nst: 336, ctr: 328)] public igHandleMetaField _Entity_Tag_0x150 = new();
        [FieldAttr(nst: 344, ctr: 336)] public igHandleMetaField _Entity_0x158 = new();
        [FieldAttr(nst: 352, ctr: 344)] public igHandleMetaField _DebugUpdateChannelVariable_id_wkhn8tmd_variable = new();
        [FieldAttr(nst: 360, ctr: 352)] public bool _Bool_0x168;
        [FieldAttr(nst: 368, ctr: 360)] public igHandleMetaField _Game_Bool_Variable_0x170 = new();
        [FieldAttr(nst: 376, ctr: 368)] public bool _Bool_0x178;
        [FieldAttr(nst: 384, ctr: 376)] public igHandleMetaField _Entity_Tag_0x180 = new();
        [FieldAttr(nst: 392, ctr: 384)] public igHandleMetaField _Entity_Tag_0x188 = new();
        [FieldAttr(nst: 400, ctr: 392)] public igHandleMetaField _Sound_0x190 = new();
        [FieldAttr(nst: 408, ctr: 400)] public igHandleMetaField _Entity_Tag_0x198 = new();
    }
}
