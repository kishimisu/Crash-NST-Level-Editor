namespace Alchemy
{
    [ObjectAttr(nst: 112, ctr: 104, align: 4, metaType: typeof(CVscComponentData))]
    public class GameObject_Platform_SplineData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public EigEaseType _TellEaseType;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _StartTrigger = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _EndTrigger = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Temple_Platform_Spline = new();
        [FieldAttr(nst: 72, ctr: 64)] public float _TellEase;
        [FieldAttr(nst: 76, ctr: 68)] public float _TellBobDuration;
        [FieldAttr(nst: 80, ctr: 72)] public float _TellDisplacement;
        [FieldAttr(nst: 84, ctr: 76)] public float _DurationBeforeMovement;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _StepReactionSFX = new();
        [FieldAttr(nst: 96, ctr: 88)] public string? _StepReactionAnimation = null;
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _StepReactionVFX = new();
    }
}
