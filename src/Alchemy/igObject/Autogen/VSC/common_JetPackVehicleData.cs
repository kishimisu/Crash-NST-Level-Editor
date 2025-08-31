namespace Alchemy
{
    // VSC object extracted from: common_JetPackVehicle.igz

    [ObjectAttr(104, metaType: typeof(CVscComponentData))]
    public class common_JetPackVehicleData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Entity_0x28 = new();
        [FieldAttr(48)] public float _MoveCrashCenterEaseRatioOut;
        [FieldAttr(52)] public EigEaseType _MoveCrashCenterEaseType;
        [FieldAttr(56)] public float _MoveCrashCenterTime_0x38;
        [FieldAttr(60)] public float _MoveCrashCenterEaseRatioIn;
        [FieldAttr(64)] public igHandleMetaField _Entity_0x40 = new();
        [FieldAttr(72)] public float _MoveCrashCenterTime_0x48;
        [FieldAttr(80)] public string? _String_0x50 = null;
        [FieldAttr(88)] public string? _String_0x58 = null;
        [FieldAttr(96)] public igHandleMetaField _Sound = new();
    }
}
