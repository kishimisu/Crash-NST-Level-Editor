namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class T154_Oxide_Station_MotherShipData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity_0x20 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity_0x28 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igVec3fMetaField _Vec_3F = new();
        [FieldAttr(nst: 68, ctr: 60)] public float _Float;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Vfx_Effect = new();
    }
}
