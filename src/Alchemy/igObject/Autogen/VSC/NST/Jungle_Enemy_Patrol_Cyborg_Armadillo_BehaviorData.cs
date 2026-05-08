namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class Jungle_Enemy_Patrol_Cyborg_Armadillo_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igVec3fMetaField _Vec_3F = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Waypoint_List = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _Float_0x40;
        [FieldAttr(nst: 68, ctr: 60)] public float _Float_0x44;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Entity = new();
    }
}
