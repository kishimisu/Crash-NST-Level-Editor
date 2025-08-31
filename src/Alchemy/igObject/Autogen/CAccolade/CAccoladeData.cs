namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class CAccoladeData : igNamedObject
    {
        public enum EQuestType : int
        {
            eQT_Invalid = -1,
            eQT_Generic = 0,
            eQT_Element = 1,
            eQT_Unique = 2,
            eQT_Count = 3,
        }

        [ObjectAttr(1)]
        public class BitfieldStorage : igBitFieldMetaField
        {
            [FieldAttr(0, size: 3)] public int _starsToAward = 1;
            [FieldAttr(3, size: 1)] public bool _resetOnRequirementsLost;
            [FieldAttr(4, size: 1)] public bool _displayProgress = false;
            [FieldAttr(5, size: 1)] public bool _showAccoladeHud = false;
            [FieldAttr(6, size: 1)] public bool _displayProgressBar = false;
            [FieldAttr(7, size: 1)] public bool _showOverCutscene;
        }

        [FieldAttr(24)] public CAccoladeRequirementList? _requirements;
        [FieldAttr(32)] public CAccoladeGoalDataList? _goals;
        [FieldAttr(40)] public EQuestType _questType = CAccoladeData.EQuestType.eQT_Invalid;
        [FieldAttr(44)] public EAccoladeGroup _accoladeGroup = EAccoladeGroup.eAG_Invalid;
        [FieldAttr(48)] public int _achievementId = -1;
        [FieldAttr(52)] public int _trophyId = -1;
        [FieldAttr(56)] public string? _steamAchievementId = "";
        [FieldAttr(64)] public uint _trophyPackServiceLabel;
        [FieldAttr(72)] public igHandleMetaField _achievementEvent = new();
        [FieldAttr(80)] public igHandleMetaField _prerequisiteBeforeDisplay = new();
        [FieldAttr(88)] public string? _shortDescription = null;
        [FieldAttr(96)] public float _displayPercentInterval = 0.25f;
        [FieldAttr(100)] public int _stardustToAward;
        [FieldAttr(104)] public BitfieldStorage _bitfieldStorage = new();
        [FieldAttr(105)] public bool _saveGameClip;
        [FieldAttr(108)] public float _clipDuration = 10.0f;
    }
}
