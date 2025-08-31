namespace Alchemy
{
    // VSC object extracted from: common_ChaseActivated_FallAwayPlatforms.igz

    [ObjectAttr(128, metaType: typeof(CVscComponentData))]
    public class common_ChaseActivated_FallAwayPlatformsData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Entity_Tag = new();
        [FieldAttr(48)] public float _TellBobDuration;
        [FieldAttr(52)] public float _TellDisplacement;
        [FieldAttr(56)] public float _Float_0x38;
        [FieldAttr(60)] public EigEaseType _TellEaseType;
        [FieldAttr(64)] public float _TellEase;
        [FieldAttr(72)] public igHandleMetaField _TellSound = new();
        [FieldAttr(80)] public igHandleMetaField _TellVFX = new();
        [FieldAttr(88)] public float _Float_0x58;
        [FieldAttr(96)] public igHandleMetaField _Sound = new();
        [FieldAttr(104)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(112)] public float _DurationDown;
        [FieldAttr(116)] public EigEaseType _EaseType;
        [FieldAttr(120)] public float _EaseDuration;
        [FieldAttr(124)] public float _DropOffest;
    }
}
