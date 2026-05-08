namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 48, align: 4, metaType: typeof(CVscComponentData))]
    public class B303_NTropy_RoomLight_Base_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _Bool;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Vfx_Effect = new();
    }
}
