namespace Alchemy
{
    // VSC object extracted from: GameObject_Platform_Spline_c.igz

    [ObjectAttr(112, metaType: typeof(CVscComponentData))]
    public class GameObject_Platform_SplineData : CVscComponentData
    {
        [FieldAttr(40)] public EigEaseType _TellEaseType;
        [FieldAttr(48)] public igHandleMetaField _StartTrigger = new();
        [FieldAttr(56)] public igHandleMetaField _EndTrigger = new();
        [FieldAttr(64)] public igHandleMetaField _Temple_Platform_Spline = new();
        [FieldAttr(72)] public float _TellEase;
        [FieldAttr(76)] public float _TellBobDuration;
        [FieldAttr(80)] public float _TellDisplacement;
        [FieldAttr(84)] public float _DurationBeforeMovement;
        [FieldAttr(88)] public igHandleMetaField _StepReactionSFX = new();
        [FieldAttr(96)] public string? _StepReactionAnimation = null;
        [FieldAttr(104)] public igHandleMetaField _StepReactionVFX = new();
    }
}
