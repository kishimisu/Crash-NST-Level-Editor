namespace Alchemy
{
    [ObjectAttr(nst: 464, ctr: 496, align: 16)]
    public class CAirArcadeCamera : CConstrainedCamera
    {
        [FieldAttr(nst: 432, ctr: 464)] public float _lookAheadDistance = 5000.0f;
        [FieldAttr(nst: 436, ctr: 468)] public float _followDistance = 4000.0f;
        [FieldAttr(nst: 440, ctr: 472)] public CCameraScreenSafeArea? _offsetScreenSafeArea;
        [FieldAttr(nst: 448, ctr: 480)] public float _horizontalScreenToWorldScale = 1.0f;
        [FieldAttr(nst: 452, ctr: 484)] public float _verticalScreenToWorldScale = 1.0f;
    }
}
