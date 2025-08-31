namespace Alchemy
{
    [ObjectAttr(104, 8)]
    public class CGuiBehaviorPlayerHudHealthBarScale : igGuiBehavior
    {
        [FieldAttr(16)] public bool _displayVehicleShields;
        [FieldAttr(24, false)] public igGuiAnimationTag? _healthBarScaleAnimation;
        [FieldAttr(32)] public igGuiAnimationCategory? _healthBarScaleCategory;
        [FieldAttr(40)] public igRangedFloatMetaField _healthBarScaleAnimationTimeRange = new();
        [FieldAttr(48)] public float _healthBarDangerThreshold = 0.2f;
        [FieldAttr(56, false)] public igGuiAnimationTag? _healthBarDangerAnimation;
        [FieldAttr(64)] public igGuiAnimationCategory? _healthBarDangerCategory;
        [FieldAttr(72, false)] public igGuiAnimationTag? _vehicleShieldRecover;
        [FieldAttr(80)] public igGuiAnimationCategory? _vehicleShieldCategory;
        [FieldAttr(88)] public EPlayerId _player = EPlayerId.EPLAYERID_NONE;
        [FieldAttr(92)] public bool _playingDangerAnimation;
        [FieldAttr(93)] public bool _fakeZeroHealth;
        [FieldAttr(96)] public float _lastAnimTime = -1.0f;
    }
}
