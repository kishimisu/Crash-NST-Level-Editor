namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Crash1_Hub_IsleDataHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _CrashHubSplineEntity = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _CameraSplineEntity = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _TransitionPreviousIsleCameraSplineEntity = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _TransitionNextIsleCameraSplineEntity = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _MapSpotList = new();
    }
}
