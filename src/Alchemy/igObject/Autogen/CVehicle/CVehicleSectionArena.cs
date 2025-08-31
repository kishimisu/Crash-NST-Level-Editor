namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CVehicleSectionArena : CVehicleSection
    {
        [FieldAttr(72)] public float _airOffsetFromSpline = 500.0f;
        [FieldAttr(76)] public bool _useOverrideSpinBias;
        [FieldAttr(80)] public float _landSpinBiasOverride;
    }
}
