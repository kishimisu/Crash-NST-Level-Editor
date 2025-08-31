namespace Alchemy
{
    // VSC object extracted from: common_InvisiblePlatform_MaterialSwap_c.igz

    [ObjectAttr(72, metaType: typeof(CVscComponentData))]
    public class common_InvisiblePlatform_MaterialSwapData : CVscComponentData
    {
        [FieldAttr(40)] public bool _RemoveOverride;
        [FieldAttr(48)] public igHandleMetaField _StartingMaterial = new();
        [FieldAttr(56)] public igHandleMetaField _NewMaterial = new();
        [FieldAttr(64)] public bool _Bool;
    }
}
