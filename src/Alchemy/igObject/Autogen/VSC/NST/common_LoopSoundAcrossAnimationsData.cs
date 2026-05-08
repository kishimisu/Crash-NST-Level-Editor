namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class common_LoopSoundAcrossAnimationsData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _RestartSoundUponAnimationChange;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _LoopingSound = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _AttackSound = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Animations = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Sound = new();
    }
}
