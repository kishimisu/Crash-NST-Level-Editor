namespace Alchemy
{
    [ObjectAttr(160, 8)]
    public class CCombatController : CCoreCameraController
    {
        [FieldAttr(144)] public CStackBlender.EBlendType _yawBlendType_1;
        [FieldAttr(148)] public float _yawDamping_1 = 0.02f;
        [FieldAttr(152)] public bool _autoEnable = true;
        [FieldAttr(156)] public float _durationBeforeMaintainHeading = 1.0f;
    }
}
