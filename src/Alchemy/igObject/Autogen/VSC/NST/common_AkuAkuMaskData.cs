namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class common_AkuAkuMaskData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _MaskLightDuration;
        [FieldAttr(nst: 44, ctr: 36)] public float _CameraLightDuration;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _idleVFX = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _MaskLightVFX = new();
    }
}
