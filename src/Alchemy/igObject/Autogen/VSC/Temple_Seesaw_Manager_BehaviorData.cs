namespace Alchemy
{
    // VSC object extracted from: Temple_Seesaw_Manager_Behavior_c.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class Temple_Seesaw_Manager_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _RotatorEntityData = new();
        [FieldAttr(48)] public igHandleMetaField _PlatformHazardsList = new();
        [FieldAttr(56)] public float _RotateDuration;
        [FieldAttr(60)] public float _ResetDuration;
    }
}
