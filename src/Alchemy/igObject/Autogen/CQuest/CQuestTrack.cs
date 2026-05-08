namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 104, align: 8)]
    public class CQuestTrack : igObject
    {
        [FieldAttr(nst: 16, ctr: 16)] public igHandleMetaField _netNextActiveQuest = new();
        [FieldAttr(nst: 24, ctr: 24)] public bool _netForceNoActiveQuest;
        [FieldAttr(nst: 32, ctr: 32)] public string? _name = null;
        [FieldAttr(nst: 40, ctr: 40)] public CQuestList? _quests;
        [FieldAttr(nst: 48, ctr: 48)] public igHandleMetaField _prerequisiteQuest = new();
        [FieldAttr(nst: 56, ctr: 56)] public int _maxQuestsPerDay;
        [FieldAttr(nst: 64, ctr: 64)] public CAchievementEvent? _achievementEvent;
        [FieldAttr(nst: 72, ctr: 72)] public bool _isReplicated = true;
        [FieldAttr(nst: 80, ctr: 80)] public igHandleMetaField _activeQuest = new();
        [FieldAttr(nst: 88, ctr: 88)] public int _questsToday;
        [FieldAttr(nst: 92, ctr: 92)] public uint _day;
        [FieldAttr(nst: 96, ctr: 96)] public int _questsCompleted;
    }
}
