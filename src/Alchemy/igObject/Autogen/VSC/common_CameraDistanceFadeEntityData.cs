namespace Alchemy
{
    // VSC object extracted from: common_CameraDistanceFadeEntity.igz

    [ObjectAttr(80, metaType: typeof(CVscComponentData))]
    public class common_CameraDistanceFadeEntityData : CVscComponentData
    {
        public enum ENewEnum9_id_i9rbjcfh
        {
            NoFade = 0,
            Small = 1,
            Large = 2,
            Medium = 3,
        }

        [FieldAttr(40)] public igHandleMetaField _Vfx_Effect_0x28 = new();
        [FieldAttr(48)] public ENewEnum9_id_i9rbjcfh _NewEnum9_id_i9rbjcfh;
        [FieldAttr(56)] public igHandleMetaField _Vfx_Effect_0x38 = new();
        [FieldAttr(64)] public igHandleMetaField _Vfx_Effect_0x40 = new();
        [FieldAttr(72)] public bool _Bool;
    }
}
