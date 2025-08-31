namespace Alchemy
{
    // VSC object extracted from: common_Crash_ResultScreen_PressToContinue_c.igz

    [ObjectAttr(80, metaType: typeof(igGuiVscBehavior))]
    public class common_Crash_ResultScreen_PressToContinue : igGuiVscBehavior
    {
        [FieldAttr(40)] public bool _isPressContinueOn;
        [FieldAttr(48)] public igHandleMetaField _LoadMapFadeOut = new();
        [FieldAttr(56)] public igHandleMetaField _AnimationIdle = new();
        [FieldAttr(64)] public igGuiInput.ESignal _InputButton;
        [FieldAttr(72)] public igHandleMetaField _Entity = new();
    }
}
