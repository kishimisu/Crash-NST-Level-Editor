namespace Alchemy
{
    [ObjectAttr(nst: 144, ctr: 136, align: 4, metaType: typeof(CVscComponentData))]
    public class Prehistoric_Enemy_Pterodactyl_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _Spawn_0x28 = null;
        [FieldAttr(nst: 48, ctr: 40)] public string? _Spawn_0x30 = null;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Zone_Info = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 72, ctr: 64)] public bool _Bool;
        [FieldAttr(nst: 80, ctr: 72)] public string? _Spawn_0x50 = null;
        [FieldAttr(nst: 88, ctr: 80)] public string? _String_0x58 = null;
        [FieldAttr(nst: 96, ctr: 88)] public string? _String_0x60 = null;
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Game_Int_Variable = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Fade_Out_Preset_Data = new();
        [FieldAttr(nst: 128, ctr: 120)] public ECrashSecretZones _E_Crash_Secret_Zones;
        [FieldAttr(nst: 136, ctr: 128)] public string? _String_0x88 = null;
    }
}
