namespace Alchemy
{
    [ObjectAttr(64, 8, metaType: typeof(CPlayerDisableAttackMessage))]
    public class CPlayerDisableAttackMessage : CEntityMessage
    {
        [FieldAttr(56)] public uint _attacks = 7;
        [FieldAttr(60)] public bool _disable = true;
    }
}
