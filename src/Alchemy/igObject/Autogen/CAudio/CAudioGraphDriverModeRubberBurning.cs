namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CAudioGraphDriverModeRubberBurning : CAudioGraphDriverMode
    {
        [FieldAttr(56)] public float _idleEngineValue;
        [FieldAttr(60)] public float _failedEngineValue = 0.3f;
        [FieldAttr(64)] public float _successEngineValue = 0.8f;
        [FieldAttr(68)] public igRangedFloatMetaField _engineRange = new();
    }
}
