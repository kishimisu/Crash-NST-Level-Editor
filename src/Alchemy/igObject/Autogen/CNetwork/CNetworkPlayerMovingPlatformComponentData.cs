namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class CNetworkPlayerMovingPlatformComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public float _smoothing = 0.15f;
        [FieldAttr(28)] public float _smoothingFalloffTime = 0.25f;
        [FieldAttr(32)] public float _maxSmoothingDistance = 500.0f;
    }
}
