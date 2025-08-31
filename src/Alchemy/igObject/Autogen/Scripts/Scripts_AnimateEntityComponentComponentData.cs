namespace Alchemy
{
    [ObjectAttr(80, 8, metaType: typeof(CDotNetEntityComponentData_1))]
    public class Scripts_AnimateEntityComponentComponentData : NovaScript_CDotNetEntityComponentData_1_Scripts_AnimateEntityComponent_
    {
        [FieldAttr(40)] public bool PlayAnimationToSelf;
        [FieldAttr(48)] public string? AnimationToPlay = null;
        [FieldAttr(56)] public bool IsLooping;
        [FieldAttr(57)] public bool PlayOnEnable;
        [FieldAttr(58)] public bool ResetOnActivate = true;
        [FieldAttr(64)] public CTelegramList? TimedTelegrams;
        [FieldAttr(72)] public int MaxTelegramsToSend = -1;
    }
}
