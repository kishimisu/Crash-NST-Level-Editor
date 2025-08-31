namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CVertexWibbleMaterialFeature : igObject
    {
        [FieldAttr(16, false)] public igFxMaterial? _owner;
        [FieldAttr(24)] public igVec3fMetaField _amplitude = new();
        [FieldAttr(36)] public igVec3fMetaField _frequency = new();
        [FieldAttr(48)] public igVec3fMetaField _phase = new();
        [FieldAttr(60)] public bool _flipVertexPhase;
        [FieldAttr(64)] public float _randomFrequencyVariance;
    }
}
