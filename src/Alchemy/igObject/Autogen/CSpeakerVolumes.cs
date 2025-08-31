namespace Alchemy
{
    [ObjectAttr(48, 4)]
    public class CSpeakerVolumes : igObject
    {
        [FieldAttr(16)] public float _leftFrontVolume = 1.0f;
        [FieldAttr(20)] public float _rightFrontVolume = 1.0f;
        [FieldAttr(24)] public float _centerVolume;
        [FieldAttr(28)] public float _leftBackVolume;
        [FieldAttr(32)] public float _rightBackVolume;
        [FieldAttr(36)] public float _leftCenterVolume;
        [FieldAttr(40)] public float _rightCenterVolume;
        [FieldAttr(44)] public float _lowFrequencyVolume;
    }
}
