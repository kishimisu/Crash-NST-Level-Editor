namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class CCESetFlags : CCombatNodeEvent
    {
        [FieldAttr(80)] public ECombatTargetSelect mTarget = ECombatTargetSelect.eCTS_Self;
        [FieldAttr(84)] public bool mReset;
        [FieldAttr(88)] public EFlagsWrapperList? mFlagList;
    }
}
