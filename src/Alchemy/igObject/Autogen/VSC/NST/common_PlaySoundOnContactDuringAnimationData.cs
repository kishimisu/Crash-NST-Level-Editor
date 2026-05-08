namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class common_PlaySoundOnContactDuringAnimationData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _ContactSound = new();
        [FieldAttr(nst: 48, ctr: 40)] public string? _AnimationState = null;
        [FieldAttr(nst: 56, ctr: 48)] public string? _AnimationState2 = null;
    }
}
