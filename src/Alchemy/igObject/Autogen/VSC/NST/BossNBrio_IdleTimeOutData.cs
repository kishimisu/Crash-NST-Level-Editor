namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 48, align: 4, metaType: typeof(CVscComponentData))]
    public class BossNBrio_IdleTimeOutData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _TimeOutRangeMin;
        [FieldAttr(nst: 44, ctr: 36)] public float _TimeOutRangeMax;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _BehaviorEventTimeOutList = new();
    }
}
