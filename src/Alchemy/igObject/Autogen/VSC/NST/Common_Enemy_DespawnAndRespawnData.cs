namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class Common_Enemy_DespawnAndRespawnData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Vfx_Effect_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Vfx_Effect_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public bool _Bool;
        [FieldAttr(nst: 60, ctr: 52)] public float _Float_0x3c;
        [FieldAttr(nst: 64, ctr: 56)] public float _Float_0x40;
    }
}
