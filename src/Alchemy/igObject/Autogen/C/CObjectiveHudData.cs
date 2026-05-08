namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 8)]
    public class CObjectiveHudData : igObject
    {
        public enum EObjectiveType
        {
            eOT_Quest = 0,
            eOT_LevelGoal = 1,
            eOT_Collectible = 2,
            eOT_Hint = 3,
        }

        public enum EDisplayState
        {
            eDS_NotVisible = 0,
            eDS_DrawingOn = 1,
            eDS_Visible = 2,
            eDS_DrawingOff = 3,
        }

        [ObjectAttr(size: 4)]
        public class FlagsBitfield : igBitFieldMetaField
        {
            [FieldAttr(offset: 0, size: 3)] public CObjectiveHudData.EObjectiveType _objectiveType;
            [FieldAttr(offset: 3, size: 1)] public bool _completed;
            [FieldAttr(offset: 4, size: 1)] public bool _displayCounter;
            [FieldAttr(offset: 5, size: 1)] public bool _keepCounterVisible;
            [FieldAttr(offset: 6, size: 2)] public CLevelGoal.ELevelStars _levelStar = CLevelGoal.ELevelStars.eLS_Land;
            [FieldAttr(offset: 8, size: 3)] public CObjectiveHudData.EDisplayState _displayState;
            [FieldAttr(offset: 11, size: 1)] public bool _hasBeenDisplayedBefore;
            [FieldAttr(offset: 12, size: 1)] public bool _incrementing;
            [FieldAttr(offset: 13, size: 1)] public bool _displayedAsComplete;
            [FieldAttr(offset: 14, size: 8)] public u8 _addedOrder;
            [FieldAttr(offset: 22, size: 4)] public CGuiManager_EPriority _guiPriority = CGuiManager_EPriority.eP_Screenspace;
        }

        [FieldAttr(nst: 16, ctr: 12)] public FlagsBitfield _flagsBitfield = new();
        [FieldAttr(nst: 24, ctr: 16)] public string? _title = null;
        [FieldAttr(nst: 32, ctr: 24)] public string? _description = null;
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _icon = new();
        [FieldAttr(nst: 48, ctr: 40)] public int _progress;
        [FieldAttr(nst: 52, ctr: 44)] public int _targetProgress = 1;
        [FieldAttr(nst: 56, ctr: 48)] public int _displayProgress;
    }
}
