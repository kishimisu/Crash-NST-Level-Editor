namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CVehicleCameraPanCollision : CVehicleCameraCollision
    {
        [FieldAttr(48)] public float _rayLength = 300.0f;
        [FieldAttr(52)] public float _rayFractionToConsiderAsGlitch = 0.5f;
    }
}
