namespace Alchemy
{
    [ObjectAttr(144, 8)]
    public class igSkinnedModelDrawCall : igModelDrawCall
    {
        [FieldAttr(128)] public igRawRefMetaField _blendVectors = new();
        [FieldAttr(136)] public igRawRefMetaField _blendVectorsPrevious = new();
    }
}
