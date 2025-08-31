namespace Alchemy
{
    [ObjectAttr(128, 8)]
    public class igModelDrawCall : igDrawCall
    {
        [FieldAttr(24, false)] public igModelDrawCallData? _data;
        [FieldAttr(32)] public igRawRefMetaField _transform = new();
        [FieldAttr(40)] public igRawRefMetaField _transformPrevious = new();
        [FieldAttr(48)] public igRawRefMetaField _morphWeights = new();
        [FieldAttr(56)] public igRawRefMetaField _morphWeightsPrevious = new();
        [FieldAttr(64, false)] public igGraphicsMaterial? _material;
        [FieldAttr(72)] public int _stencilRef;
        [FieldAttr(80, false)] public igShaderConstantBundleList? _constantBundles;
        [FieldAttr(88)] public int _dynamicConstantBundles;
        [FieldAttr(96, false)] public igShaderConstantBundleList? _dataConstantBundles;
        [FieldAttr(104, false)] public igModelInstance? _instance;
        [FieldAttr(112)] public igTimeMetaField _instanceTime = new();
        [FieldAttr(116)] public float[] _fadeLevels = new float[2];
        [FieldAttr(124)] public int _visited;
    }
}
