namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CGuiBehaviorBossHealthBar : igGuiBehavior
    {
        [FieldAttr(16, false)] public igGuiAnimationTag? _healthAnimation;
        [FieldAttr(24, false)] public igGuiPlaceable? _nameText;
        [FieldAttr(32, false)] public igGuiPlaceable? _healthText;
        [FieldAttr(40, false)] public igGuiPlaceable? _portrait;
        [FieldAttr(48)] public igHandleMetaField _bossHandle = new();
        [FieldAttr(56)] public bool _fadingOut;
    }
}
