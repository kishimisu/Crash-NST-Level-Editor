namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class CPlayerFollowData : igObject
    {
        [FieldAttr(16)] public float _followRatio = 1.0f;
        [FieldAttr(20)] public float _maxAngle = 10.0f;
    }
}
