namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class T508_Toxic_MotherShip_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity_0x28 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Entity_0x40 = new();
    }
}
