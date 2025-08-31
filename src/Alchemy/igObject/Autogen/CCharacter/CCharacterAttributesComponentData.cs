namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CCharacterAttributesComponentData : igComponentData
    {
        [FieldAttr(24)] public CCharacterAttributes? _baseAttributes;
    }
}
