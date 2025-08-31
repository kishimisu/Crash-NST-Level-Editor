namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CSoundUpdateVelocityBased : CSoundUpdateMethod
    {
        [FieldAttr(48)] public float _minVelocity;
        [FieldAttr(52)] public float _maxVelocity = 100.0f;
    }
}
