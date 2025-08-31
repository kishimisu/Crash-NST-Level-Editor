namespace Alchemy
{
    [ObjectAttr(312, 8)]
    public class CIridescentMaterialFeature : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _owner = new();
        [FieldAttr(24)] public igVfxRangedCurveMetaField _colorRed = new();
        [FieldAttr(108)] public igVfxRangedCurveMetaField _colorGreen = new();
        [FieldAttr(192)] public igVfxRangedCurveMetaField _colorBlue = new();
        [FieldAttr(276)] public float _gloss = 0.8f;
        [FieldAttr(280)] public float _metalness = 1.0f;
        [FieldAttr(284)] public float _emissive;
        [FieldAttr(288)] public float _distance;
        [FieldAttr(292)] public float _falloff;
        [FieldAttr(296)] public bool _flipFalloff;
        [FieldAttr(300)] public float _overallContribution = 1.0f;
        [FieldAttr(304)] public bool _useNormalMap = true;
        [FieldAttr(305)] public bool _useHalfAngle;
        [FieldAttr(306)] public bool _useFixedHalfAngle;
    }
}
