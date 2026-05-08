namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 64, align: 8)]
    public class CQuestStep : igObject
    {
        public enum EState
        {
            eS_NotStarted = 0,
            eS_Objective = 1,
            eS_OutroInteraction = 2,
            eS_Completed = 3,
        }

        [FieldAttr(nst: 16, ctr: 16)] public CObjective? _objective;
        [FieldAttr(nst: 24, ctr: 24)] public CQuestInteraction? _inProgressInteraction;
        [FieldAttr(nst: 32, ctr: 32)] public CQuestInteraction? _stepOutroInteraction;
        [FieldAttr(nst: 40, ctr: 40)] public bool _cancelObjectiveOnLevelLoad;
        [FieldAttr(nst: 48, ctr: 48)] public igHandleMetaField _quest = new();
        [FieldAttr(nst: 56, ctr: 56)] public EState _state;
    }
}
