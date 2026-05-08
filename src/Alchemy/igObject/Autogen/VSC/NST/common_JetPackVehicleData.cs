namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 96, align: 4, metaType: typeof(CVscComponentData))]
    public class common_JetPackVehicleData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _MoveCrashCenterEaseRatioOut;
        [FieldAttr(nst: 52, ctr: 44)] public EigEaseType _MoveCrashCenterEaseType;
        [FieldAttr(nst: 56, ctr: 48)] public float _MoveCrashCenterTime_0x38;
        [FieldAttr(nst: 60, ctr: 52)] public float _MoveCrashCenterEaseRatioIn;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Entity_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public float _MoveCrashCenterTime_0x48;
        [FieldAttr(nst: 80, ctr: 72)] public string? _String_0x50 = null;
        [FieldAttr(nst: 88, ctr: 80)] public string? _String_0x58 = null;
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Sound = new();
    }
}
