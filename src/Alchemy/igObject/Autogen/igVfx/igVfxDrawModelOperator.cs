namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class igVfxDrawModelOperator : igVfxDrawOperator
    {
        [FieldAttr(32)] public string? _modelNameInternal = null;
        [FieldAttr(40)] public igHandleMetaField _sceneHandle = new();
        [FieldAttr(48)] public igModelData? _modelData;
        [FieldAttr(56)] public bool _fitToScale;
        [FieldAttr(60)] public u32 /* igStructMetaField */ _instanceData;
        [FieldAttr(64, false)] public igRenderer? _renderer;
    }
}
