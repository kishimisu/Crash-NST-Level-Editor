namespace Alchemy
{
    [ObjectAttr(nst: 144, ctr: 136, align: 4, metaType: typeof(CVscComponentData))]
    public class Hazard_Fire_Projectile_On_EnterData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _ProjectileData = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _Float;
        [FieldAttr(nst: 64, ctr: 56)] public string? _String_0x40 = null;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Vfx_Effect_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public string? _String_0x50 = null;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Vfx_Effect_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Vfx_Effect_0x60 = new();
        [FieldAttr(nst: 104, ctr: 96)] public string? _String_0x68 = null;
        [FieldAttr(nst: 112, ctr: 104)] public igVec3fMetaField _Vec_3F = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Sound_0x80 = new();
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _Sound_0x88 = new();
    }
}
