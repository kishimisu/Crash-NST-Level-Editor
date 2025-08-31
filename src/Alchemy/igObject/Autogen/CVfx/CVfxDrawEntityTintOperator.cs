namespace Alchemy
{
    [ObjectAttr(312, 4)]
    public class CVfxDrawEntityTintOperator : igVfxDrawOperator
    {
        [FieldAttr(32)] public igVfxRangedCurveMetaField _colorIntensity = new();
        [FieldAttr(116)] public EOperatorCurveInput _intensityInput;
        [FieldAttr(120)] public igVfxRangedCurveMetaField _emissive = new();
        [FieldAttr(204)] public EOperatorCurveInput _emissiveInput;
        [FieldAttr(208)] public igVfxRangedCurveMetaField _emissiveBlend = new();
        [FieldAttr(292)] public EOperatorCurveInput _blendInput;
        [FieldAttr(296)] public float _priority;
        [FieldAttr(300)] public bool _applyToBoltOns = true;
        [FieldAttr(304)] public u32 /* igStructMetaField */ _instance;
        [FieldAttr(308)] public u32 /* igStructMetaField */ _primitive;
    }
}
