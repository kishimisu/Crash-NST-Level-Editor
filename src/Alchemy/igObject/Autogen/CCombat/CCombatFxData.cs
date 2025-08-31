namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CCombatFxData : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _hitEffect = new();
        [FieldAttr(24)] public igHandleMetaField _hitFlashEffect = new();
        [FieldAttr(32)] public igHandleMetaField _killHitEffect = new();
        [FieldAttr(40)] public igHandleMetaField _killFlashEffect = new();
    }
}
