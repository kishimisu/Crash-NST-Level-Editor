namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(CVscComponentData))]
    public class common_ChaseActivated_FallAwayPlatformsData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity_Tag = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _TellBobDuration;
        [FieldAttr(nst: 52, ctr: 44)] public float _TellDisplacement;
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
        [FieldAttr(nst: 60, ctr: 52)] public EigEaseType _TellEaseType;
        [FieldAttr(nst: 64, ctr: 56)] public float _TellEase;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _TellSound = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _TellVFX = new();
        [FieldAttr(nst: 88, ctr: 80)] public float _Float_0x58;
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 112, ctr: 104)] public float _DurationDown;
        [FieldAttr(nst: 116, ctr: 108)] public EigEaseType _EaseType;
        [FieldAttr(nst: 120, ctr: 112)] public float _EaseDuration;
        [FieldAttr(nst: 124, ctr: 116)] public float _DropOffest;
    }
}
