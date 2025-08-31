namespace Alchemy
{
    // VSC object extracted from: common_Crate_Checkpoint_Sequence_c.igz

    [ObjectAttr(96, metaType: typeof(CVscComponentData))]
    public class common_Crate_Checkpoint_SequenceData : CVscComponentData
    {
        [FieldAttr(40)] public bool _IsIronCrate;
        [FieldAttr(48)] public igHandleMetaField _CheckpointSound = new();
        [FieldAttr(56)] public igHandleMetaField _OpenSound = new();
        [FieldAttr(64)] public string? _OpenAnimation = null;
        [FieldAttr(72)] public igHandleMetaField _OpenVFX = new();
        [FieldAttr(80)] public bool _Bool;
        [FieldAttr(88)] public igHandleMetaField _Sound = new();
    }
}
