namespace Alchemy
{
    // VSC object extracted from: B106_DrNeoCortex_BossMovement_Handler_c.igz

    [ObjectAttr(144, metaType: typeof(CVscComponentData))]
    public class B106_DrNeoCortex_BossMovement_HandlerData : CVscComponentData
    {
        [FieldAttr(40)] public EigEaseType _EaseType;
        [FieldAttr(44)] public EigEaseType _IntroMoveEaseType;
        [FieldAttr(48)] public igHandleMetaField _IntroSplineScreenLeft = new();
        [FieldAttr(56)] public igHandleMetaField _IntroSplineMoverScreenLeft = new();
        [FieldAttr(64)] public igHandleMetaField _IntroSplineScreenRight = new();
        [FieldAttr(72)] public igHandleMetaField _IntroSplineMoverScreenRight = new();
        [FieldAttr(80)] public float _Speed;
        [FieldAttr(84)] public float _EaseRatioIn;
        [FieldAttr(88)] public float _EaseRatioOut;
        [FieldAttr(92)] public float _IntroPlayerRelativeXAxisRange;
        [FieldAttr(96)] public float _IntroMoveToTauntTime;
        [FieldAttr(100)] public float _IntroMoveEaseRatioIn;
        [FieldAttr(104)] public float _IntroMoveEaseRatioOut;
        [FieldAttr(108)] public float _IntroTauntTime;
        [FieldAttr(112)] public float _IntroMoveToEndTime;
        [FieldAttr(120)] public igHandleMetaField _IntroMoveToTauntSplineMarkerScreenLeft = new();
        [FieldAttr(128)] public igHandleMetaField _IntroMoveToTauntSplineMarkerScreenRight = new();
        [FieldAttr(136)] public igHandleMetaField _MoveToWaypointList = new();
    }
}
