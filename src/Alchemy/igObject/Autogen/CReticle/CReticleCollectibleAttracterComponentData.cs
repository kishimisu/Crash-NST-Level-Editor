namespace Alchemy
{
    [ObjectAttr(48, 4)]
    public class CReticleCollectibleAttracterComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public float _minDistanceFromCamera = 100.0f;
        [FieldAttr(28)] public float _attractRadiusMultiplier = 0.15f;
        [FieldAttr(32)] public ECombatTargetList _targetList;
        [FieldAttr(36)] public bool _autoCollect = true;
        [FieldAttr(40)] public EXBUTTON _attractCollectibleButton = EXBUTTON.B;
        [FieldAttr(44)] public bool _useVehiclePassengerInput = true;
    }
}
