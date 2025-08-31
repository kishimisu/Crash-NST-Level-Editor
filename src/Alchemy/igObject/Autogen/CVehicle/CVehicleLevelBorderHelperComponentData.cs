namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class CVehicleLevelBorderHelperComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public float _distanceCheckForBorder = 5000.0f;
        [FieldAttr(28)] public float _detectionZOffset = 200.0f;
        [FieldAttr(32)] public float _spawnOffset = 200.0f;
    }
}
