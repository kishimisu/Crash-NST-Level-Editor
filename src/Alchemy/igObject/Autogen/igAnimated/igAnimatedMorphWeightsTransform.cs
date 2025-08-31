namespace Alchemy
{
    [ObjectAttr(48, 16)]
    public class igAnimatedMorphWeightsTransform : igObject
    {
        [FieldAttr(16)] public igVec4fMetaField _weights = new();
        [FieldAttr(32)] public igAnimatedMorphWeights? _source;
    }
}
