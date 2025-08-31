namespace Alchemy
{
    [ObjectAttr(80, 8, metaObject: true)]
    public class CBehaviorLogic : CBaseBehaviorLogic
    {
        [FieldAttr(24)] public igRawRefMetaField _dynamicFieldMemory = new();
        [FieldAttr(32)] public igStringStringHashTable? _activators;
        [FieldAttr(40)] public igStringStringHashTable? _excludeActivators;
        [FieldAttr(48)] public CBaseUpgradeFilter? _skillUpgradeFilter;
        [FieldAttr(56)] public CBaseVehicleModeFilter? _vehicleModeFilter;
        [FieldAttr(64)] public bool _playerOnly;
        [FieldAttr(65)] public bool _useProxy;
        [FieldAttr(66)] public bool _useProxyInputOnly;
        [FieldAttr(67)] public bool _useProxyPassengerOnly;
        [FieldAttr(68)] public bool _disable;
        [FieldAttr(72, false)] public igMetaObject? _meta = (null);
    }
}
