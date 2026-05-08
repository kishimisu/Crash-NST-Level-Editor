namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class common_CameraDistanceFadeEntityData : CVscComponentData
    {
        public enum ENewEnum9_id_i9rbjcfh
        {
            NoFade = 0,
            Small = 1,
            Large = 2,
            Medium = 3,
        }

        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Vfx_Effect_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public ENewEnum9_id_i9rbjcfh _NewEnum9_id_i9rbjcfh;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Vfx_Effect_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Vfx_Effect_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public bool _Bool;
    }
}
