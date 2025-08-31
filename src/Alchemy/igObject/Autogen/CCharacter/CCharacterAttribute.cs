namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class CCharacterAttribute : igObject
    {
        [FieldAttr(16)] public ECharacterAttribute _attribute = ECharacterAttribute.eCA_MaximumHealth;
        [FieldAttr(20)] public float _value;
    }
}
