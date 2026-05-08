namespace Alchemy
{
    [ObjectAttr(nst: 176, ctr: 176, align: 8)]
    public class CQuest : igObject
    {
        public enum EQuestPriority
        {
            eQP_Other = 1,
            eQP_Seasonal = 2,
            eQP_Story = 3,
        }

        [FieldAttr(nst: 16, ctr: 16)] public string? _title = null;
        [FieldAttr(nst: 24, ctr: 24)] public EQuestPriority _priority = CQuest.EQuestPriority.eQP_Other;
        [FieldAttr(nst: 32, ctr: 32)] public igHandleMetaField _prerequisite = new();
        [FieldAttr(nst: 40, ctr: 40)] public CQuestRequirement? _requirement;
        [FieldAttr(nst: 48, ctr: 48)] public CQuestInteraction? _introInteraction;
        [FieldAttr(nst: 56, ctr: 56)] public CQuestStepList? _questSteps;
        [FieldAttr(nst: 64, ctr: 64)] public CQuestInteraction? _outroInteraction;
        [FieldAttr(nst: 72, ctr: 72)] public bool _isRepeatable;
        [FieldAttr(nst: 76, ctr: 76)] public int _questDuration;
        [FieldAttr(nst: 80, ctr: 80)] public int kOutroIndex;
        [FieldAttr(nst: 84, ctr: 84)] public int kRewardIndex;
        [FieldAttr(nst: 88, ctr: 88)] public int kResolvedIndex;
        [FieldAttr(nst: 92, ctr: 92)] public bool _isActive;
        [FieldAttr(nst: 96, ctr: 96)] public int _currentStepIndex = -2;
        [FieldAttr(nst: 104, ctr: 104)] public u64 _lastInteractedTimestamp;
        [FieldAttr(nst: 112, ctr: 112, refCount: false)] public CQuestInteraction? _currentInteraction;
        [FieldAttr(nst: 120, ctr: 120)] public CQuestEventDelegate? _onQuestStart;
        [FieldAttr(nst: 128, ctr: 128)] public CQuestStartEventList? _onQuestStartEventList;
        [FieldAttr(nst: 136, ctr: 136)] public uint _dayQuestStarted;
        [FieldAttr(nst: 144, ctr: 144)] public CQuestEventList? _onQuestCompleteList;
        [FieldAttr(nst: 152, ctr: 152)] public uint _replicatedQuestBitfield;
        [FieldAttr(nst: 160, ctr: 160)] public CQuestSaveData? _replicatedSaveData;
        [FieldAttr(nst: 168, ctr: 168)] public bool _rewardSequenceComplete;
    }
}
