namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CAudioGraphDriverModeSurfaceStationary : CAudioGraphDriverModeTargetBased
    {
        [FieldAttr(72)] public float _graphInput;
        [FieldAttr(76)] public float _noVelocityThreshold = 5.0f;
    }
}
