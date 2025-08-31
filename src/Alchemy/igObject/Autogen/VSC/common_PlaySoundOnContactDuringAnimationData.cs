namespace Alchemy
{
    // VSC object extracted from: common_PlaySoundOnContactDuringAnimation_c.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class common_PlaySoundOnContactDuringAnimationData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _ContactSound = new();
        [FieldAttr(48)] public string? _AnimationState = null;
        [FieldAttr(56)] public string? _AnimationState2 = null;
    }
}
