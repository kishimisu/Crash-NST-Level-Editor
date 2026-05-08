namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 96, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Motorcycle_RampData : CVscComponentData
    {
        public enum ENewEnum9_id_17u0u40s
        {
            NoFade = 0,
            Small = 1,
            Large = 2,
            Medium = 3,
        }

        [FieldAttr(nst: 40, ctr: 32)] public igVec3fMetaField _Vec_3F_0x28 = new();
        [FieldAttr(nst: 52, ctr: 44)] public igVec3fMetaField _Vec_3F_0x34 = new();
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool;
        [FieldAttr(nst: 68, ctr: 60)] public ENewEnum9_id_17u0u40s _NewEnum9_id_17u0u40s;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Vfx_Effect_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Vfx_Effect_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Vfx_Effect_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Waypoint = new();
    }
}
