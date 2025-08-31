namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class CKnockawayLandData : igObject
    {
        [FieldAttr(16)] public float _dampeningFactor;
        [FieldAttr(20)] public float _standUpSpeedThreshold = 1.25f;
    }
}
