namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class CMotionBlurData : igObject
    {
        [FieldAttr(16)] public float _cameraBlurStrength = 1.0f;
        [FieldAttr(20)] public float _exposureTime = 0.34999999f;
    }
}
