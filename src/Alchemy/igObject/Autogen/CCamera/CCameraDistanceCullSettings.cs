namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class CCameraDistanceCullSettings : igObject
    {
        [FieldAttr(16)] public float _cullDistanceVeryLow = 4000.0f;
        [FieldAttr(20)] public float _cullDistanceLow = 8000.0f;
        [FieldAttr(24)] public float _cullDistanceMedium = 16000.0f;
        [FieldAttr(28)] public float _cullDistanceHigh = 24000.0f;
        [FieldAttr(32)] public float _distanceCullFadeRange = 500.0f;
    }
}
