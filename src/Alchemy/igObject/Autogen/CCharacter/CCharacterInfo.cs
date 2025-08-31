namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CCharacterInfo : igObject
    {
        [FieldAttr(16)] public int _frame;
        [FieldAttr(20)] public float _widthAdjust;
        [FieldAttr(24)] public float _kernTL;
        [FieldAttr(28)] public float _kernTR;
        [FieldAttr(32)] public float _kernBL;
        [FieldAttr(36)] public float _kernBR;
        [FieldAttr(40)] public string? _referenceCharacter = null;
    }
}
