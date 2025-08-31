namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CAudioGraph : igObject
    {
        [FieldAttr(16)] public float _minUsablePercent;
        [FieldAttr(20)] public float _maxUsablePercent = 100.0f;
        [FieldAttr(24)] public CAudioGraphModuleList? _modules;
        [FieldAttr(32)] public float _maxInputPercentIncreasePerFrame = 100.0f;
        [FieldAttr(36)] public float _maxInputPercentDecreasePerFrame = 100.0f;
        [FieldAttr(40)] public float _currentPercent;
        [FieldAttr(44)] public bool _enableModules = true;
        [FieldAttr(48)] public int _graphID = -1;
        [FieldAttr(52)] public float _testInputPercent;
        [FieldAttr(56)] public bool _useTestInputPercent;
    }
}
