namespace Alchemy
{
    [ObjectAttr(120, 8)]
    public class CCESimpleEffect : CCombatNodeEvent
    {
        public enum EKillOnEndMode : uint
        {
            eKOEM_None = 0,
            eKOEM_SoftKill = 1,
            eKOEM_HardKill = 2,
        }

        [FieldAttr(80)] public igHandleMetaField _effect = new();
        [FieldAttr(88)] public bool _attemptFireAndForget = true;
        [FieldAttr(89)] public bool _preventDuplicates;
        [FieldAttr(96)] public CBoltPoint? _boltPoint1;
        [FieldAttr(104)] public CBoltPoint? _boltPoint2;
        [FieldAttr(112)] public EKillOnEndMode _killOnEndMode;
    }
}
