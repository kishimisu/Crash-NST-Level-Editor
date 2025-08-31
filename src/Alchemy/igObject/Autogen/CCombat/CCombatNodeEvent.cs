namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CCombatNodeEvent : igObject
    {
        public enum ECriticalType : uint
        {
            kCriticalNone = 0,
            kCriticalStart = 1,
            kCriticalEnd = 2,
            kCriticalOnInterrupt = 3,
        }

        [FieldAttr(16)] public bool _triggerOnLoop = true;
        [FieldAttr(17)] public bool _triggerWhenStateInactive;
        [FieldAttr(18)] public bool _triggerOnProxies;
        [FieldAttr(19)] public bool _timeRelativeFromEnd;
        [FieldAttr(24)] public string? _name = null;
        [FieldAttr(32)] public float _time;
        [FieldAttr(36)] public ECriticalType _critical;
        [FieldAttr(40)] public CBaseUpgradeFilter? _skillUpgradeFilter;
        [FieldAttr(48)] public CVariantIdentifierFilter? _variantIdentifierFilter;
        [FieldAttr(56)] public CBaseVehicleModeFilter? _vehicleModeFilter;
        [FieldAttr(64)] public CCombatNodeEvent? _nextEvent;
        [FieldAttr(72)] public CEntityMessage.ENetworkSendRestriction _networkRestriction;
        [FieldAttr(76)] public uint _deviceClass = 31;
    }
}
