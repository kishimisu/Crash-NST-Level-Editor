namespace Alchemy
{
    // VSC object extracted from: BossNBrio_SmashPotion_Handler_c.igz

    [ObjectAttr(72, metaType: typeof(CVscComponentData))]
    public class BossNBrio_SmashPotion_HandlerData : CVscComponentData
    {
        [FieldAttr(40)] public bool _IsSmashPotionEnableOnStart;
        [FieldAttr(48)] public igHandleMetaField _TriggerSmashPotionReadyTemplate = new();
        [FieldAttr(56)] public igHandleMetaField _TriggerSmashPotionAttackTemplate = new();
        [FieldAttr(64)] public float _Float;
    }
}
