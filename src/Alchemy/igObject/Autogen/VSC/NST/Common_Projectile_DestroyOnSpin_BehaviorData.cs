namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 40, align: 4, metaType: typeof(CVscComponentData))]
    public class Common_Projectile_DestroyOnSpin_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity_Tag = new();
    }
}
