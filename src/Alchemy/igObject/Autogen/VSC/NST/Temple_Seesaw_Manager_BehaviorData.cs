namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class Temple_Seesaw_Manager_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _RotatorEntityData = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _PlatformHazardsList = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _RotateDuration;
        [FieldAttr(nst: 60, ctr: 52)] public float _ResetDuration;
    }
}
