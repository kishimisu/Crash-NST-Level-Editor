namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CWorldData : igObject
    {
        [FieldAttr(16)] public bool _canSwapHeroes = true;
        [FieldAttr(17)] public bool _createHeroes = true;
        [FieldAttr(20)] public float _lightVisibilityDistance = 3700.0f;
        [FieldAttr(24)] public float _lightVisibilityRange = 300.0f;
        [FieldAttr(28)] public float _cullDistanceVeryLow = 4000.0f;
        [FieldAttr(32)] public float _cullDistanceLow = 8000.0f;
        [FieldAttr(36)] public float _cullDistanceMedium = 16000.0f;
        [FieldAttr(40)] public float _cullDistanceHigh = 24000.0f;
        [FieldAttr(44)] public float _distanceCullFadeRange = 500.0f;
        [FieldAttr(48)] public CWorldCollectibleModifierTable? _worldCollectibleModifiers;
    }
}
