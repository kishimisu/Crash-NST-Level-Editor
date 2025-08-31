namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CAmbientOcclusionRenderData : igObject
    {
        [FieldAttr(16)] public float _radius = 50.0f;
        [FieldAttr(20)] public float _scale = 1.39999998f;
        [FieldAttr(24)] public float _bias = 1.0f;
    }
}
