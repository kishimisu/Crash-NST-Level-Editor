namespace Alchemy
{
    [ObjectAttr(208, 16)]
    public class igModelData : igNamedObject
    {
        [FieldAttr(32)] public igVec4fMetaField _min = new();
        [FieldAttr(48)] public igVec4fMetaField _max = new();
        [FieldAttr(64)] public igVectorMetaField<igAnimatedTransform> _transforms = new();
        [FieldAttr(88)] public igVectorMetaField<int> _transformHierarchy = new();
        [FieldAttr(112)] public igVectorMetaField<igModelDrawCallData> _drawCalls = new();
        [FieldAttr(136)] public igVectorMetaField<int> _drawCallTransformIndices = new();
        [FieldAttr(160)] public igVectorMetaField<igAnimatedMorphWeightsTransform> _morphWeightTransforms = new();
        [FieldAttr(184)] public igVectorMetaField<int> _blendMatrixIndices = new();
    }
}
