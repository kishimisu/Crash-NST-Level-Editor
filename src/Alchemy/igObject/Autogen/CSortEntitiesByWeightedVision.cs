namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class CSortEntitiesByWeightedVision : CSortEntities
    {
        [FieldAttr(16)] public float _angleWeightFactor = 1.0f;
        [FieldAttr(20)] public float _distWeightFactor = 1.0f;
    }
}
