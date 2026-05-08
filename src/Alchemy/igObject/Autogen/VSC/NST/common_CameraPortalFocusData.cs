namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class common_CameraPortalFocusData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public EigEaseType _Ease_Type;
        [FieldAttr(nst: 44, ctr: 36)] public EigEaseMode _Ease_Mode;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 56, ctr: 48)] public igVec3fMetaField _Vector3 = new();
        [FieldAttr(nst: 68, ctr: 60)] public bool _Bool;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Camera_Base = new();
    }
}
