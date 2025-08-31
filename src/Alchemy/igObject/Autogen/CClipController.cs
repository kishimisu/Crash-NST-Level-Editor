namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CClipController : CStackCameraControllerBase
    {
        [FieldAttr(56)] public float _distanceDamping = 0.05f;
    }
}
