namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class BossNGin_C3Mech01_MoveHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public EigEaseType _Ease_Type;
        [FieldAttr(nst: 44, ctr: 36)] public float _Float_0x2c;
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x30;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Waypoint = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Spline_Rotation_Mover = new();
    }
}
