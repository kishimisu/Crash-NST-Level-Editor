namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class common_C1_BossCortex_BlueHazardData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _DamageData = new();
        [FieldAttr(nst: 48, ctr: 40)] public EigEaseType _BobEaseType;
        [FieldAttr(nst: 52, ctr: 44)] public float _BobEaseRatioIn;
        [FieldAttr(nst: 56, ctr: 48)] public float _BobEaseRatioOut;
        [FieldAttr(nst: 60, ctr: 52)] public float _BobZOffset;
        [FieldAttr(nst: 64, ctr: 56)] public float _BobSpeed;
    }
}
