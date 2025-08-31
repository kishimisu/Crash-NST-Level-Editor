namespace Alchemy
{
    // VSC object extracted from: common_LoopSoundAcrossAnimations_c.igz

    [ObjectAttr(80, metaType: typeof(CVscComponentData))]
    public class common_LoopSoundAcrossAnimationsData : CVscComponentData
    {
        [FieldAttr(40)] public bool _RestartSoundUponAnimationChange;
        [FieldAttr(48)] public igHandleMetaField _LoopingSound = new();
        [FieldAttr(56)] public igHandleMetaField _AttackSound = new();
        [FieldAttr(64)] public igHandleMetaField _Animations = new();
        [FieldAttr(72)] public igHandleMetaField _Sound = new();
    }
}
