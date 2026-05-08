namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Crate_TNTData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _One = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Three = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Two = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _WarningSound = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _WarningVFX = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _IdleVFX = new();
        [FieldAttr(nst: 88, ctr: 80)] public float _Float;
    }
}
