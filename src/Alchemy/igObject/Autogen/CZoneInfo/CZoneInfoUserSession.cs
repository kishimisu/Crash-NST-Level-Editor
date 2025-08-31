namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CZoneInfoUserSession : igObject
    {
        [FieldAttr(16)] public uint _storyModeRecordStarsMask;
        [FieldAttr(20)] public int _storyModeRecordPercentComplete;
        [FieldAttr(24)] public EDifficultyLevel _storyModeHighestDifficulty = EDifficultyLevel.eDL_Invalid;
        [FieldAttr(28)] public int _storyModeLevelCompletions;
        [FieldAttr(32)] public int _storyModeHighScore;
        [FieldAttr(36)] public int _timeTrialFirstPlaceTime;
        [FieldAttr(40)] public int _timeTrialSecondPlaceTime;
        [FieldAttr(44)] public int _timeTrialThirdPlaceTime;
        [FieldAttr(48)] public string? _timeTrialFirstPlaceInitials = "---";
        [FieldAttr(56)] public string? _timeTrialSecondPlaceInitials = "---";
        [FieldAttr(64)] public string? _timeTrialThirdPlaceInitials = "---";
        [FieldAttr(72)] public int _timeTrialRelicCompleted;
        [FieldAttr(76)] public bool _powerCrystalCollected;
        [FieldAttr(80)] public uint _collectiblesRewarded;
        [FieldAttr(84)] public bool _timeTrialDataSentToLeaderboards;
    }
}
