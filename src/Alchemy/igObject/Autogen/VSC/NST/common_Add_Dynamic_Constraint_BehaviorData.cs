namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Add_Dynamic_Constraint_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Havok_Ball_And_Socket_Constraint_Data = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _Float;
    }
}
