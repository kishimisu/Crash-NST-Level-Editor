namespace Alchemy
{
    // VSC object extracted from: BlasterTech_CarrotControl_c.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class BlasterTech_CarrotControlData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _CarrotBehaviorStates = new();
        [FieldAttr(48)] public igHandleMetaField _CarrotRecticleEntityData = new();
        [FieldAttr(56)] public igHandleMetaField _FindTargetsQuery = new();
    }
}
