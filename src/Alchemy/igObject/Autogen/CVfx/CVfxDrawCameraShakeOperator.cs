namespace Alchemy
{
    [ObjectAttr(160, 4)]
    public class CVfxDrawCameraShakeOperator : igVfxDrawOperator
    {
        [FieldAttr(32)] public igVfxRangedCurveMetaField _magnitude = new();
        [FieldAttr(116)] public igRangedFloatMetaField _scale = new();
        [FieldAttr(124)] public igRangedFloatMetaField _speed = new();
        [FieldAttr(132)] public bool _isForceFeedbackEnabled = true;
        [FieldAttr(133)] public bool _isFalloffEnabled = true;
        [FieldAttr(136)] public igRangedFloatMetaField _innerRadius = new();
        [FieldAttr(144)] public igRangedFloatMetaField _outerRadius = new();
        [FieldAttr(152)] public u32 /* igStructMetaField */ _instanceData;
    }
}
