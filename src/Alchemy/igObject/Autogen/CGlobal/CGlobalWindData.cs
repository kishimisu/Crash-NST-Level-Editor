namespace Alchemy
{
    [ObjectAttr(72, 4)]
    public class CGlobalWindData : igObject
    {
        [FieldAttr(16)] public float _windStrength = 0.25f;
        [FieldAttr(20)] public igVec3fMetaField _windDirection = new();
        [FieldAttr(32)] public float _gustFrequency = 0.1f;
        [FieldAttr(36)] public float _gustPrimaryDistance = 24.0f;
        [FieldAttr(40)] public float _gustScale = 5.0f;
        [FieldAttr(44)] public float _gustStrengthMin;
        [FieldAttr(48)] public float _gustStrengthMax = 0.6f;
        [FieldAttr(52)] public float _gustDurationMin = 1.0f;
        [FieldAttr(56)] public float _gustDurationMax = 3.0f;
        [FieldAttr(60)] public float _gustDirectionAdjustment;
        [FieldAttr(64)] public float _gustUnison = 0.85f;
    }
}
