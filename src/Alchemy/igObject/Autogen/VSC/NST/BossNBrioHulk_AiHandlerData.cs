namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class BossNBrioHulk_AiHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _BossNBrioHulkDamageData = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _ChargeMoveXDistanceMax;
        [FieldAttr(nst: 52, ctr: 44)] public float _ChargeWidth;
        [FieldAttr(nst: 56, ctr: 48)] public float _ReturnTime;
        [FieldAttr(nst: 60, ctr: 52)] public float _ReturnJumpHeight;
        [FieldAttr(nst: 64, ctr: 56)] public float _ChargePlayerAdjustYRangeStrength;
        [FieldAttr(nst: 68, ctr: 60)] public float _ChargePlayerDistanceMin;
        [FieldAttr(nst: 72, ctr: 64)] public float _ChargePlayerYAheadOffset;
        [FieldAttr(nst: 76, ctr: 68)] public float _Float_0x4c;
        [FieldAttr(nst: 80, ctr: 72)] public float _Float_0x50;
        [FieldAttr(nst: 84, ctr: 76)] public float _Float_0x54;
    }
}
