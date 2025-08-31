namespace Alchemy
{
    // VSC object extracted from: common_Button_Generic_c.igz

    [ObjectAttr(184, metaType: typeof(igGuiVscBehavior))]
    public class common_Button_Generic : igGuiVscBehavior
    {
        [FieldAttr(40)] public bool _Focused_On_Start;
        [FieldAttr(44)] public EGuiMenuSound _NavigationSound;
        [FieldAttr(48)] public igHandleMetaField _FocusAnimationCategory = new();
        [FieldAttr(56)] public igHandleMetaField _AnimationPress = new();
        [FieldAttr(64)] public igHandleMetaField _AnimationLoseFocus = new();
        [FieldAttr(72)] public igHandleMetaField _AnimationGainFocus = new();
        [FieldAttr(80)] public igHandleMetaField _ButtonSpritePlaceable = new();
        [FieldAttr(88)] public igHandleMetaField _GuiPlaceableVariable_id_30pylgup_variable = new();
        [FieldAttr(96)] public igHandleMetaField _ButtonTextPlaceable = new();
        [FieldAttr(104)] public igHandleMetaField _ButtonToTheDown = new();
        [FieldAttr(112)] public igHandleMetaField _ButtonToTheUp = new();
        [FieldAttr(120)] public igHandleMetaField _ButtonToTheRight = new();
        [FieldAttr(128)] public igHandleMetaField _ButtonToTheLeft = new();
        [FieldAttr(136)] public igHandleMetaField _Button_Material = new();
        [FieldAttr(144)] public igObject? _Internal_TimerAction_id_amfz1mz4_timer = new();
        [FieldAttr(152)] public igHandleMetaField _Button_Text = new();
        [FieldAttr(160)] public igHandleMetaField _InputMaterial = new();
        [FieldAttr(168)] public bool _InputFocus;
        [FieldAttr(176)] public igObject? _Localized_String = new();
    }
}
