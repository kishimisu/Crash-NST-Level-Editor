namespace Alchemy
{
    // VSC object extracted from: common_Crash1_Hub_IsleDataHandler_c.igz

    [ObjectAttr(80, metaType: typeof(CVscComponentData))]
    public class common_Crash1_Hub_IsleDataHandlerData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _CrashHubSplineEntity = new();
        [FieldAttr(48)] public igHandleMetaField _CameraSplineEntity = new();
        [FieldAttr(56)] public igHandleMetaField _TransitionPreviousIsleCameraSplineEntity = new();
        [FieldAttr(64)] public igHandleMetaField _TransitionNextIsleCameraSplineEntity = new();
        [FieldAttr(72)] public igHandleMetaField _MapSpotList = new();
    }
}
