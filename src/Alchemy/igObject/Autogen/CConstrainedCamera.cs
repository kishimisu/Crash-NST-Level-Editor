namespace Alchemy
{
    [ObjectAttr(432, 16)]
    public class CConstrainedCamera : CCamera
    {
        [FieldAttr(416)] public float _targetRadiusMin = 600.0f;
        [FieldAttr(420)] public float _targetRadiusMax = 800.0f;
        [FieldAttr(424)] public CCameraScreenSafeArea? _screenSafeArea;
    }
}
