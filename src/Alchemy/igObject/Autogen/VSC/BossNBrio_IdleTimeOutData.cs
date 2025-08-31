namespace Alchemy
{
    // VSC object extracted from: BossNBrio_IdleTimeOut_c.igz

    [ObjectAttr(56, metaType: typeof(CVscComponentData))]
    public class BossNBrio_IdleTimeOutData : CVscComponentData
    {
        [FieldAttr(40)] public float _TimeOutRangeMin;
        [FieldAttr(44)] public float _TimeOutRangeMax;
        [FieldAttr(48)] public igHandleMetaField _BehaviorEventTimeOutList = new();
    }
}
