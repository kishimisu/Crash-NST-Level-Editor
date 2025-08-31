namespace Alchemy
{
    // VSC object extracted from: common_Crash1_Hub_CameraManager_c.igz

    [ObjectAttr(144, metaType: typeof(CVscComponentData))]
    public class common_Crash1_Hub_CameraManagerData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _IsleTransitionCamera = new();
        [FieldAttr(48)] public EigEaseType _MoveToMapSpotEaseType;
        [FieldAttr(52)] public EigEaseType _IsleTransitionCameraSplineMoveEaseType;
        [FieldAttr(56)] public EigEaseType _IsleTransitionCameraBlendInEaseType;
        [FieldAttr(64)] public igHandleMetaField _CameraAttachProxy = new();
        [FieldAttr(72)] public igHandleMetaField _IsleTransitionCameraAttachProxy = new();
        [FieldAttr(80)] public float _MoveToMapSpotEaseRatioIn;
        [FieldAttr(84)] public float _MoveToMapSpotEaseRatioOut;
        [FieldAttr(88)] public float _IsleTransitionCameraSplineMoveTime;
        [FieldAttr(92)] public float _IsleTransitionCameraSplineMoveEaseRatioIn;
        [FieldAttr(96)] public float _IsleTransitionCameraSplineMoveEaseRatioOut;
        [FieldAttr(100)] public float _IsleTransitionCameraBlendTimeIn;
        [FieldAttr(104)] public igKeyboardInputDevice.ESignal _DebugInputLogCameraCurrentSplineDistance;
        [FieldAttr(108)] public float _Float_0x6c;
        [FieldAttr(112)] public float _Float_0x70;
        [FieldAttr(116)] public float _Float_0x74;
        [FieldAttr(120)] public igHandleMetaField _Entity_0x78 = new();
        [FieldAttr(128)] public igHandleMetaField _Entity_0x80 = new();
        [FieldAttr(136)] public float _Float_0x88;
    }
}
