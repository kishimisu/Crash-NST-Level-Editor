namespace Alchemy
{
    // VSC object extracted from: PauseMenu_Root_c.igz

    [ObjectAttr(120, metaType: typeof(igGuiVscBehavior))]
    public class PauseMenu_Root : igGuiVscBehavior
    {
        [FieldAttr(40)] public igHandleMetaField _AnimationIdle = new();
        [FieldAttr(48)] public igHandleMetaField _TitleScreenZoneInfo = new();
        [FieldAttr(56)] public igHandleMetaField _localCurrZoneInfo = new();
        [FieldAttr(64)] public igObject? _Internal_GateAction_id_jn9wtv7a_gate = new();
        [FieldAttr(72)] public int _InternalStore__internalCounter;
        [FieldAttr(80)] public igHandleMetaField _LevelName = new();
        [FieldAttr(88)] public igHandleMetaField _Gui_Placeable = new();
        [FieldAttr(96)] public igHandleMetaField _Gui_Animation_Tag_0x60 = new();
        [FieldAttr(104)] public igHandleMetaField _Gui_Animation_Tag_0x68 = new();
        [FieldAttr(112)] public float _Float;
    }
}
