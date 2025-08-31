namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CPlayerAttackComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public float _heightToBeginJumpAttacks = 100.0f;
        [FieldAttr(32)] public CPlayerAttackDataTable? _dataTable;
    }
}
