namespace Alchemy
{
    // VSC object extracted from: common_CameraPortalFocus.igz

    [ObjectAttr(80, metaType: typeof(CVscComponentData))]
    public class common_CameraPortalFocusData : CVscComponentData
    {
        [FieldAttr(40)] public EigEaseType _Ease_Type;
        [FieldAttr(44)] public EigEaseMode _Ease_Mode;
        [FieldAttr(48)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(56)] public igVec3fMetaField _Vector3 = new();
        [FieldAttr(68)] public bool _Bool;
        [FieldAttr(72)] public igHandleMetaField _Camera_Base = new();
    }
}
