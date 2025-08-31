namespace Alchemy
{
    // VSC object extracted from: common_Motorcycle_Ramp.igz

    [ObjectAttr(104, metaType: typeof(CVscComponentData))]
    public class common_Motorcycle_RampData : CVscComponentData
    {
        public enum ENewEnum9_id_17u0u40s
        {
            NoFade = 0,
            Small = 1,
            Large = 2,
            Medium = 3,
        }

        [FieldAttr(40)] public igVec3fMetaField _Vec_3F_0x28 = new();
        [FieldAttr(52)] public igVec3fMetaField _Vec_3F_0x34 = new();
        [FieldAttr(64)] public bool _Bool;
        [FieldAttr(68)] public ENewEnum9_id_17u0u40s _NewEnum9_id_17u0u40s;
        [FieldAttr(72)] public igHandleMetaField _Vfx_Effect_0x48 = new();
        [FieldAttr(80)] public igHandleMetaField _Vfx_Effect_0x50 = new();
        [FieldAttr(88)] public igHandleMetaField _Vfx_Effect_0x58 = new();
        [FieldAttr(96)] public igHandleMetaField _Waypoint = new();
    }
}
