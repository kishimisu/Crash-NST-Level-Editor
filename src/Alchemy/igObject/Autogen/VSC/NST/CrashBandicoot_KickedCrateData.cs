namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 48, align: 4, metaType: typeof(CVscComponentData))]
    public class CrashBandicoot_KickedCrateData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _StartCountdown;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _StationaryCrate = new();
    }
}
