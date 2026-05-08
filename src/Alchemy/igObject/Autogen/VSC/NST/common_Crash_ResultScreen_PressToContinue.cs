namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class common_Crash_ResultScreen_PressToContinue : igGuiVscBehavior
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _isPressContinueOn;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _LoadMapFadeOut = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _AnimationIdle = new();
        [FieldAttr(nst: 64, ctr: 56)] public igGuiInput.ESignal _InputButton;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Entity = new();
    }
}
