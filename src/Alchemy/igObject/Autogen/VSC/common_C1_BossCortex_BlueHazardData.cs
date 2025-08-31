namespace Alchemy
{
    // VSC object extracted from: common_C1_BossCortex_BlueHazard_c.igz

    [ObjectAttr(72, metaType: typeof(CVscComponentData))]
    public class common_C1_BossCortex_BlueHazardData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _DamageData = new();
        [FieldAttr(48)] public EigEaseType _BobEaseType;
        [FieldAttr(52)] public float _BobEaseRatioIn;
        [FieldAttr(56)] public float _BobEaseRatioOut;
        [FieldAttr(60)] public float _BobZOffset;
        [FieldAttr(64)] public float _BobSpeed;
    }
}
