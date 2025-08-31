namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CControllerButtonCharacterMap : igObject
    {
        [FieldAttr(16)] public EControllerType _controllerType;
        [FieldAttr(24)] public igStringStringHashTable? _characterMap;
    }
}
