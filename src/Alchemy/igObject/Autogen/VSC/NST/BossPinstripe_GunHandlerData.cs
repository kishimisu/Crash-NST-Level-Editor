namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class BossPinstripe_GunHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity_Data = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x30;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Projectile_Spawn_Data = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _Float_0x40;
    }
}
