namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Crate_Checkpoint_SequenceData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _IsIronCrate;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _CheckpointSound = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _OpenSound = new();
        [FieldAttr(nst: 64, ctr: 56)] public string? _OpenAnimation = null;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _OpenVFX = new();
        [FieldAttr(nst: 80, ctr: 72)] public bool _Bool;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Sound = new();
    }
}
