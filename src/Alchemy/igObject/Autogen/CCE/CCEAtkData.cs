namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CCEAtkData : igObject
    {
        [FieldAttr(16)] public float _maxRange;
        [FieldAttr(20)] public float _dot;
        [FieldAttr(24)] public bool _ignoreHeroes;
        [FieldAttr(32)] public CAttackBone? _attackBone;
    }
}
