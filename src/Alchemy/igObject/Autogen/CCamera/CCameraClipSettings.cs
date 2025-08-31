namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class CCameraClipSettings : igObject
    {
        [FieldAttr(16)] public float _nearPlane = 32.0f;
        [FieldAttr(20)] public float _farPlane = 2.0f;
    }
}
