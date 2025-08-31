namespace Alchemy
{
    // VSC object extracted from: common_BossMoveHandler.igz

    [ObjectAttr(72, metaType: typeof(CVscComponentData))]
    public class BossNGin_C3Mech01_MoveHandlerData : CVscComponentData
    {
        [FieldAttr(40)] public EigEaseType _Ease_Type;
        [FieldAttr(44)] public float _Float_0x2c;
        [FieldAttr(48)] public float _Float_0x30;
        [FieldAttr(56)] public igHandleMetaField _Waypoint = new();
        [FieldAttr(64)] public igHandleMetaField _Spline_Rotation_Mover = new();
    }
}
