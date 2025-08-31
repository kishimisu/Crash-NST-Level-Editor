namespace Alchemy
{
    [ObjectAttr(168, 8)]
    public class CGuiBehaviorDamageNumber : igGuiBehavior
    {
        [FieldAttr(16, false)] public igGuiPlaceable? _text;
        [FieldAttr(24, false)] public igGuiPlaceable? _iconPlaceable;
        [FieldAttr(32, false)] public igGuiPlaceable? _baneIconPlaceable;
        [FieldAttr(40, false)] public igGuiSprite? _icon;
        [FieldAttr(48, false)] public igGuiAnimationTag? _damageAnimation;
        [FieldAttr(56, false)] public igGuiAnimationTag? _damageFromPlayerAnimation;
        [FieldAttr(64, false)] public igGuiAnimationTag? _criticalDamageAnimation;
        [FieldAttr(72, false)] public igGuiAnimationTag? _healthAnimation;
        [FieldAttr(80, false)] public igGuiAnimationTag? _statBoostAnimation;
        [FieldAttr(88, false)] public igGuiAnimationTag? _moneyAnimation;
        [FieldAttr(96, false)] public igGuiAnimationTag? _superchargeDamageAnimation;
        [FieldAttr(104, false)] public igGuiAnimationTag? _superchargeCritcalDamageAnimation;
        [FieldAttr(112, false)] public igGuiAnimationTag? _armorBlockedAnimation;
        [FieldAttr(120)] public igNonRefCountedGuiAnimationTagList? _customAnimations;
        [FieldAttr(128)] public float _riseSpeed;
        [FieldAttr(132)] public igVec2fMetaField _screenPosition = new();
        [FieldAttr(144)] public string? _stunText = null;
        [FieldAttr(152, false)] public CGuiDamageNumberData? _damageNumberInfo;
        [FieldAttr(160)] public bool _queuedStatBoostAnimation;
    }
}
