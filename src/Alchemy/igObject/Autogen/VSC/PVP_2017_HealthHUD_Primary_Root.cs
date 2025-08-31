namespace Alchemy
{
    // VSC object extracted from: PVP_2017_HealthHUD_Primary_Root_c.igz

    [ObjectAttr(200, metaType: typeof(igGuiVscBehavior))]
    public class PVP_2017_HealthHUD_Primary_Root : igGuiVscBehavior
    {
        [FieldAttr(40)] public igHandleMetaField _PlayerEntity = new();
        [FieldAttr(48)] public igHandleMetaField _HealthFillMiddle = new();
        [FieldAttr(56)] public igHandleMetaField _Background = new();
        [FieldAttr(64)] public igHandleMetaField _HealthFillRight = new();
        [FieldAttr(72)] public igHandleMetaField _TeamIdentifier = new();
        [FieldAttr(80)] public igHandleMetaField _BackgroundAdd = new();
        [FieldAttr(88)] public igHandleMetaField _HealthFillLeft = new();
        [FieldAttr(96)] public int _TeamNumber;
        [FieldAttr(104)] public igHandleMetaField _Team2Background = new();
        [FieldAttr(112)] public igHandleMetaField _Team1HealthBarMaterial = new();
        [FieldAttr(120)] public igHandleMetaField _Team2HealthBarMaterial = new();
        [FieldAttr(128)] public igHandleMetaField _HealthBarMaterial = new();
        [FieldAttr(136)] public igHandleMetaField _Team2BackgroundAdd = new();
        [FieldAttr(144)] public igHandleMetaField _Team1Background = new();
        [FieldAttr(152)] public igHandleMetaField _Team1BackgroundAdd = new();
        [FieldAttr(160)] public igObject? _FirstPlayer = new();
        [FieldAttr(168)] public string? _TeamName = null;
        [FieldAttr(176)] public string? _FirstPlayerTeamName = null;
        [FieldAttr(184)] public string? _StringVariable_id_iww0vl5b_variable = null;
        [FieldAttr(192)] public igObject? _Internal_TimerAction_id_23knb0on_timer = new();
    }
}
