namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CSwitchCounter : igObject
    {
        [FieldAttr(16)] public int _currentValue;
        [FieldAttr(20)] public int _maxValue;
        [FieldAttr(24)] public bool _looping;
    }
}
