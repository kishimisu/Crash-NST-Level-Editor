namespace Alchemy
{
    [ObjectAttr(496, 8)]
    public class CVfxDrawBoxLightOperator : igVfxDrawOperator
    {
        [FieldAttr(32)] public igVfxRangedCurveMetaField _nearAttenuation = new();
        [FieldAttr(116)] public igVfxRangedCurveMetaField _attenuation = new();
        [FieldAttr(200)] public igVfxRangedCurveMetaField _xFalloff = new();
        [FieldAttr(284)] public igVfxRangedCurveMetaField _yFalloff = new();
        [FieldAttr(368)] public EOperatorCurveInput _attenuationInput;
        [FieldAttr(372)] public igVfxRangedCurveMetaField _wrap = new();
        [FieldAttr(456)] public EOperatorCurveInput _wrapInput;
        [FieldAttr(464)] public string? _cookieTextureName = "loosetextures";
        [FieldAttr(472)] public bool _distanceCull = true;
        [FieldAttr(480)] public igVfxAnimatedFrame? _animatedFrame;
        [FieldAttr(488)] public u32 /* igStructMetaField */ _instance;
    }
}
