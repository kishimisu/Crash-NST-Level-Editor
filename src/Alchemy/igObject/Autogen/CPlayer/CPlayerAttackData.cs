namespace Alchemy
{
    [ObjectAttr(152, 8)]
    public class CPlayerAttackData : igObject
    {
        public enum EJumpAttackOption : uint
        {
            eJAO_Disabled = 0,
            eJAO_Normal = 1,
            eJAO_Custom = 2,
            eJAO_CustomDoNotCancel = 3,
            eJAO_CustomDelayGroundTransition = 4,
            eJAO_DoNotCancel = 5,
        }

        [FieldAttr(16)] public string? _attackEvent = null;
        [FieldAttr(24)] public string? _attackState = null;
        [FieldAttr(32)] public string? _cancelEvent = null;
        [FieldAttr(40)] public EJumpAttackOption _jumpAttackOption;
        [FieldAttr(48)] public string? _jumpAttackEvent = null;
        [FieldAttr(56)] public string? _jumpAttackState = null;
        [FieldAttr(64)] public string? _jumpAttackCancelEvent = null;
        [FieldAttr(72)] public string? _jumpAttackLandEvent = null;
        [FieldAttr(80)] public CSkillUpgradeFilter? _jumpAttackUpgradeFilter;
        [FieldAttr(88)] public float _hangTimeMaxDuration = 1.0f;
        [FieldAttr(92)] public bool _disabledDuringFall;
        [FieldAttr(93)] public bool _disabledDuringDoubleJump;
        [FieldAttr(96)] public float _maxAllowedFallDistance;
        [FieldAttr(100)] public float _minimumGroundDistance = 50.0f;
        [FieldAttr(104)] public bool _requiresRunningState;
        [FieldAttr(105)] public bool _authorityOnly;
        [FieldAttr(106)] public bool _isToggleAbility;
        [FieldAttr(107)] public bool _triggerOnHeldButton;
        [FieldAttr(108)] public float _onHeldButtonWindowTime;
        [FieldAttr(112)] public bool _cancelOnReleasedButton;
        [FieldAttr(113)] public bool _interruptOtherAttacks;
        [FieldAttr(114)] public bool _canBeInterrupted;
        [FieldAttr(116)] public float _cooldownTime;
        [FieldAttr(120)] public CUpgradeableFloat? _upgradeableCooldownTime;
        [FieldAttr(128)] public CSkillUpgradeFilter? _skillUpgradeFilter;
        [FieldAttr(136)] public bool _blockWhenCrouchedUnderCollision;
        [FieldAttr(137)] public bool _checkExtraButtons;
        [FieldAttr(140)] public EXBUTTON _extraButton1 = EXBUTTON.MAX;
        [FieldAttr(144)] public EXBUTTON _extraButton2 = EXBUTTON.MAX;
    }
}
