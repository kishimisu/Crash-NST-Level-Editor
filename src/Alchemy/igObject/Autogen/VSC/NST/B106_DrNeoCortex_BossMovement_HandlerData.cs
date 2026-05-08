namespace Alchemy
{
    [ObjectAttr(nst: 144, ctr: 136, align: 4, metaType: typeof(CVscComponentData))]
    public class B106_DrNeoCortex_BossMovement_HandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public EigEaseType _EaseType;
        [FieldAttr(nst: 44, ctr: 36)] public EigEaseType _IntroMoveEaseType;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _IntroSplineScreenLeft = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _IntroSplineMoverScreenLeft = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _IntroSplineScreenRight = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _IntroSplineMoverScreenRight = new();
        [FieldAttr(nst: 80, ctr: 72)] public float _Speed;
        [FieldAttr(nst: 84, ctr: 76)] public float _EaseRatioIn;
        [FieldAttr(nst: 88, ctr: 80)] public float _EaseRatioOut;
        [FieldAttr(nst: 92, ctr: 84)] public float _IntroPlayerRelativeXAxisRange;
        [FieldAttr(nst: 96, ctr: 88)] public float _IntroMoveToTauntTime;
        [FieldAttr(nst: 100, ctr: 92)] public float _IntroMoveEaseRatioIn;
        [FieldAttr(nst: 104, ctr: 96)] public float _IntroMoveEaseRatioOut;
        [FieldAttr(nst: 108, ctr: 100)] public float _IntroTauntTime;
        [FieldAttr(nst: 112, ctr: 104)] public float _IntroMoveToEndTime;
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _IntroMoveToTauntSplineMarkerScreenLeft = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _IntroMoveToTauntSplineMarkerScreenRight = new();
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _MoveToWaypointList = new();
    }
}
