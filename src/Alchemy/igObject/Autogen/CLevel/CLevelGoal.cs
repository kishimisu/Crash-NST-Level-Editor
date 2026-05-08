namespace Alchemy
{
    [ObjectAttr(nst: 176, ctr: 168, align: 8)]
    public class CLevelGoal : CObjective
    {
        public enum ELevelStars
        {
            eLS_Land = 0,
            eLS_Sea = 1,
            eLS_Sky = 2,
            eLS_Invalid = 3,
        }

        [FieldAttr(nst: 152, ctr: 144)] public int _progressRequiredForCompletion = 1;
        [FieldAttr(nst: 156, ctr: 148)] public bool _resetProgressOnCancel = true;
        [FieldAttr(nst: 160, ctr: 152)] public ELevelStars _levelStar = CLevelGoal.ELevelStars.eLS_Invalid;
        [FieldAttr(nst: 164, ctr: 156)] public bool _showIncrementalProgress = true;
        [FieldAttr(nst: 165, ctr: 157)] public bool _alwaysShowCounter = true;
        [FieldAttr(nst: 166, ctr: 158)] public bool _netReplicate = true;
        [FieldAttr(nst: 168, ctr: 160)] public int _progress;
    }
}
