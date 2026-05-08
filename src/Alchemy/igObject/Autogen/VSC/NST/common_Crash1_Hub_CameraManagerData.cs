namespace Alchemy
{
    [ObjectAttr(nst: 144, ctr: 136, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Crash1_Hub_CameraManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _IsleTransitionCamera = new();
        [FieldAttr(nst: 48, ctr: 40)] public EigEaseType _MoveToMapSpotEaseType;
        [FieldAttr(nst: 52, ctr: 44)] public EigEaseType _IsleTransitionCameraSplineMoveEaseType;
        [FieldAttr(nst: 56, ctr: 48)] public EigEaseType _IsleTransitionCameraBlendInEaseType;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _CameraAttachProxy = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _IsleTransitionCameraAttachProxy = new();
        [FieldAttr(nst: 80, ctr: 72)] public float _MoveToMapSpotEaseRatioIn;
        [FieldAttr(nst: 84, ctr: 76)] public float _MoveToMapSpotEaseRatioOut;
        [FieldAttr(nst: 88, ctr: 80)] public float _IsleTransitionCameraSplineMoveTime;
        [FieldAttr(nst: 92, ctr: 84)] public float _IsleTransitionCameraSplineMoveEaseRatioIn;
        [FieldAttr(nst: 96, ctr: 88)] public float _IsleTransitionCameraSplineMoveEaseRatioOut;
        [FieldAttr(nst: 100, ctr: 92)] public float _IsleTransitionCameraBlendTimeIn;
        [FieldAttr(nst: 104, ctr: 96)] public igKeyboardInputDevice.ESignal _DebugInputLogCameraCurrentSplineDistance;
        [FieldAttr(nst: 108, ctr: 100)] public float _Float_0x6c;
        [FieldAttr(nst: 112, ctr: 104)] public float _Float_0x70;
        [FieldAttr(nst: 116, ctr: 108)] public float _Float_0x74;
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Entity_0x78 = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Entity_0x80 = new();
        [FieldAttr(nst: 136, ctr: 128)] public float _Float_0x88;
    }
}
