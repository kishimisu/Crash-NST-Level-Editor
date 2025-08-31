namespace Alchemy
{
    // VSC object extracted from: Common_Enemy_HideAndReveal_c.igz

    [ObjectAttr(72, metaType: typeof(CVscComponentData))]
    public class Common_Enemy_DespawnAndRespawnData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Vfx_Effect_0x28 = new();
        [FieldAttr(48)] public igHandleMetaField _Vfx_Effect_0x30 = new();
        [FieldAttr(56)] public bool _Bool;
        [FieldAttr(60)] public float _Float_0x3c;
        [FieldAttr(64)] public float _Float_0x40;
    }
}
