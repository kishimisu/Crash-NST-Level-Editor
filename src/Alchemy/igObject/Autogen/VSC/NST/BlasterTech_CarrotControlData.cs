namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class BlasterTech_CarrotControlData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _CarrotBehaviorStates = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _CarrotRecticleEntityData = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _FindTargetsQuery = new();
    }
}
