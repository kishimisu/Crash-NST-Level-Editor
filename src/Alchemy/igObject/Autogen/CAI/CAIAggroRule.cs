namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CAIAggroRule : igObject
    {
        [FieldAttr(16)] public CFilterEntities? _filter;
        [FieldAttr(24)] public float _aggroAmount = 1.0f;
        [FieldAttr(28)] public float _distanceMax;
        [FieldAttr(32)] public float _aggroMultiplierMinDistance;
        [FieldAttr(36)] public float _aggroMultiplierAtMinDistance = 1.0f;
        [FieldAttr(40)] public float _aggroMultiplierAtMaxDistance = 1.0f;
        [FieldAttr(44)] public uint _validWithStatus = 3;
    }
}
