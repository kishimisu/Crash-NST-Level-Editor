namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class Beenox_Showroom_Script_CharacterData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Waypoint_0x20 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Camera_Base = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Waypoint_0x30 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 72, ctr: 64)] public igVec3fMetaField _Vector3 = new();
    }
}
