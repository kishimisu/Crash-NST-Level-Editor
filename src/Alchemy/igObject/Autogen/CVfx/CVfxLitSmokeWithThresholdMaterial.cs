namespace Alchemy
{
    [ObjectAttr(304, 16)]
    public class CVfxLitSmokeWithThresholdMaterial : CVfxMaterial
    {
        [FieldAttr(272)] public float _lightWrap = 0.75f;
        [FieldAttr(276)] public float _thresholdSize = 0.5f;
        [FieldAttr(288)] public igVec4fMetaField _lightWrapParameters = new();
    }
}
