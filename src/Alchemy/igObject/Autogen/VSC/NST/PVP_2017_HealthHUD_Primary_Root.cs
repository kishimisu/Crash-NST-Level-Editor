namespace Alchemy
{
    [ObjectAttr(nst: 200, ctr: 192, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class PVP_2017_HealthHUD_Primary_Root : igGuiVscBehavior
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _PlayerEntity = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _HealthFillMiddle = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Background = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _HealthFillRight = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _TeamIdentifier = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _BackgroundAdd = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _HealthFillLeft = new();
        [FieldAttr(nst: 96, ctr: 88)] public int _TeamNumber;
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Team2Background = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Team1HealthBarMaterial = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Team2HealthBarMaterial = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _HealthBarMaterial = new();
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _Team2BackgroundAdd = new();
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _Team1Background = new();
        [FieldAttr(nst: 152, ctr: 144)] public igHandleMetaField _Team1BackgroundAdd = new();
        [FieldAttr(nst: 160, ctr: 152)] public igObject? _FirstPlayer = new();
        [FieldAttr(nst: 168, ctr: 160)] public string? _TeamName = null;
        [FieldAttr(nst: 176, ctr: 168)] public string? _FirstPlayerTeamName = null;
        [FieldAttr(nst: 184, ctr: 176)] public string? _StringVariable_id_iww0vl5b_variable = null;
        [FieldAttr(nst: 192, ctr: 184)] public igObject? _Internal_TimerAction_id_23knb0on_timer = new();
    }
}
