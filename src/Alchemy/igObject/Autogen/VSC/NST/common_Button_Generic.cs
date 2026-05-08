namespace Alchemy
{
    [ObjectAttr(nst: 184, ctr: 176, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class common_Button_Generic : igGuiVscBehavior
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _Focused_On_Start;
        [FieldAttr(nst: 44, ctr: 36)] public EGuiMenuSound _NavigationSound;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _FocusAnimationCategory = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _AnimationPress = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _AnimationLoseFocus = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _AnimationGainFocus = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _ButtonSpritePlaceable = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _GuiPlaceableVariable_id_30pylgup_variable = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _ButtonTextPlaceable = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _ButtonToTheDown = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _ButtonToTheUp = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _ButtonToTheRight = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _ButtonToTheLeft = new();
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _Button_Material = new();
        [FieldAttr(nst: 144, ctr: 136)] public igObject? _Internal_TimerAction_id_amfz1mz4_timer = new();
        [FieldAttr(nst: 152, ctr: 144)] public igHandleMetaField _Button_Text = new();
        [FieldAttr(nst: 160, ctr: 152)] public igHandleMetaField _InputMaterial = new();
        [FieldAttr(nst: 168, ctr: 160)] public bool _InputFocus;
        [FieldAttr(nst: 176, ctr: 168)] public igObject? _Localized_String = new();
    }
}
