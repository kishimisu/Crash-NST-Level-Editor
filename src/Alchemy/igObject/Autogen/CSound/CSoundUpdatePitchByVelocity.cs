namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CSoundUpdatePitchByVelocity : CSoundUpdateVelocityBased
    {
        [FieldAttr(56)] public float _pitchAtMinVelocity;
        [FieldAttr(60)] public float _pitchAtMaxVelocity;
    }
}
