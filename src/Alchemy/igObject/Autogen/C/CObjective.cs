namespace Alchemy
{
    [ObjectAttr(nst: 152, ctr: 144, align: 8)]
    public class CObjective : igObject
    {
        public enum EObjectiveType
        {
            eOT_Chapter = 0,
            eOT_Optional = 1,
            eOT_Collectible = 2,
            eOT_Quest = 3,
        }

        [FieldAttr(nst: 16, ctr: 12)] public EObjectiveType _type;
        [FieldAttr(nst: 24, ctr: 16)] public string? _description = null;
        [FieldAttr(nst: 32, ctr: 24)] public igHandleMetaField _image = new();
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _objectiveEntity = new();
        [FieldAttr(nst: 48, ctr: 40)] public bool _isStarted;
        [FieldAttr(nst: 52, ctr: 44)] public CGuiManager_EPriority _guiPriority = CGuiManager_EPriority.eP_HUD;
        [FieldAttr(nst: 56, ctr: 48)] public bool _hasProgressed;
        [FieldAttr(nst: 64, ctr: 56)] public string? _questTitle = null;
        [FieldAttr(nst: 72, ctr: 64)] public bool _isAuthoritative = true;
        [FieldAttr(nst: 80, ctr: 72)] public CObjectiveHudData? _objectiveHudData;
        [FieldAttr(nst: 88, ctr: 80)] public CObjectiveEventDelegate? _onObjectiveStart;
        [FieldAttr(nst: 96, ctr: 88)] public CObjectiveEventList? _onObjectiveStartEventList;
        [FieldAttr(nst: 104, ctr: 96)] public CObjectiveEventDelegate? _onObjectiveCancel;
        [FieldAttr(nst: 112, ctr: 104)] public CObjectiveEventList? _onObjectiveCancelEventList;
        [FieldAttr(nst: 120, ctr: 112)] public CObjectiveEventDelegate? _onObjectiveComplete;
        [FieldAttr(nst: 128, ctr: 120)] public CObjectiveEventList? _onObjectiveCompleteEventList;
        [FieldAttr(nst: 136, ctr: 128)] public CObjectiveEventDelegate? _onObjectiveIncrement;
        [FieldAttr(nst: 144, ctr: 136)] public CObjectiveEventList? _onObjectiveIncrementEventList;
    }
}
