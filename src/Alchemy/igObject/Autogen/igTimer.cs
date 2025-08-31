namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igTimer : igObject
    {
        [FieldAttr(16)] public bool _active;
        [FieldAttr(20)] public igTimeMetaField _startTime = new();
        [FieldAttr(24)] public float _elapsedSeconds;
    }
}
