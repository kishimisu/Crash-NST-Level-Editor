namespace Alchemy
{
    [ObjectAttr(56, 4)]
    public class igRenderAuxiliaryCullingParameters : igObject
    {
        [FieldAttr(16)] public bool _distanceCulling;
        [FieldAttr(20)] public float[] _distanceCullStart = new float[4];
        [FieldAttr(36)] public float _distanceCullFadeRange;
        [FieldAttr(40)] public bool _smallObjectCulling;
        [FieldAttr(44)] public float _smallObjectDistance;
        [FieldAttr(48)] public float _smallObjectSize = 2.0f;
    }
}
