namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class common_InvisiblePlatform_MaterialSwapData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _RemoveOverride;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _StartingMaterial = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _NewMaterial = new();
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool;
    }
}
