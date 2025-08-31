namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CSoundUpdateVolumeByVelocity : CSoundUpdateVelocityBased
    {
        [FieldAttr(56)] public float _volumeAtMinVelocity;
        [FieldAttr(60)] public float _volumeAtMaxVelocity = 1.0f;
    }
}
