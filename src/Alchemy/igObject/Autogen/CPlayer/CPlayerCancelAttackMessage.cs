namespace Alchemy
{
    [ObjectAttr(64, 8, metaType: typeof(CPlayerCancelAttackMessage))]
    public class CPlayerCancelAttackMessage : CEntityMessage
    {
        [FieldAttr(56)] public EPlayerCancelAttackReason _cancelReason = EPlayerCancelAttackReason.ePCAR_Other;
    }
}
