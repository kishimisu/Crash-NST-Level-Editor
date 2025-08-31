namespace Alchemy
{
    [ObjectAttr(224, 4)]
    public class CVfxDrawTintSphereOperator : igVfxDrawOperator
    {
        [FieldAttr(32)] public igVfxRangedCurveMetaField _intensity = new();
        [FieldAttr(116)] public EOperatorCurveInput _intensityInput;
        [FieldAttr(120)] public igVfxRangedCurveMetaField _additiveness = new();
        [FieldAttr(204)] public EOperatorCurveInput _additivenessInput;
        [FieldAttr(208)] public bool _depthBlendingEnabled;
        [FieldAttr(212)] public float _depthBlendingSoftness = 14.0f;
        [FieldAttr(216)] public u32 /* igStructMetaField */ _instance;
    }
}
