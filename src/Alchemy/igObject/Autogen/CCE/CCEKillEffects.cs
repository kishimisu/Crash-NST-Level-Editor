namespace Alchemy
{
    [ObjectAttr(104, 8)]
    public class CCEKillEffects : CCombatNodeEvent
    {
        [FieldAttr(80)] public igHandleMetaField _effect = new();
        [FieldAttr(88)] public string? _tagName = null;
        [FieldAttr(96)] public igVfxManager.EffectKillType _killType;
    }
}
