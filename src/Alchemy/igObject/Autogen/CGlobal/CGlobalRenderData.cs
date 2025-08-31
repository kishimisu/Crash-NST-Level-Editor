namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CGlobalRenderData : igObject
    {
        [FieldAttr(16)] public float _AOMaxObscuranceDistance = 30.0f;
        [FieldAttr(20)] public float _AOConvexThreshold = 3.0f;
        [FieldAttr(24)] public float _AOOccludedSampleScale = 15.0f;
        [FieldAttr(28)] public float _AOTotalOcclusionScale = 1.75f;
    }
}
