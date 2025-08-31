namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CStackCameraBehaviorStates : igObject
    {
        [FieldAttr(16)] public igStringStringHashTable? _activators;
        [FieldAttr(24)] public igStringStringHashTable? _excludeActivators;
    }
}
