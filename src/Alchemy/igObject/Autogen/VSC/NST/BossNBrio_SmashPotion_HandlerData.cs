namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class BossNBrio_SmashPotion_HandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _IsSmashPotionEnableOnStart;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _TriggerSmashPotionReadyTemplate = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _TriggerSmashPotionAttackTemplate = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _Float;
    }
}
