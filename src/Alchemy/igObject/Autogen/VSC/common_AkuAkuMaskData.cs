namespace Alchemy
{
    // VSC object extracted from: common_AkuAkuMask_c.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class common_AkuAkuMaskData : CVscComponentData
    {
        [FieldAttr(40)] public float _MaskLightDuration;
        [FieldAttr(44)] public float _CameraLightDuration;
        [FieldAttr(48)] public igHandleMetaField _idleVFX = new();
        [FieldAttr(56)] public igHandleMetaField _MaskLightVFX = new();
    }
}
