namespace Alchemy
{
    [ObjectAttr(176, 8)]
    public class CWavePoolComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public float _collisionWaveHeightInfluenceMax = 2.0f;
        [FieldAttr(28)] public float _wave1Angle = 50.0f;
        [FieldAttr(32)] public float _wave1Length = 3600.0f;
        [FieldAttr(36)] public float _wave1Speed = 690.0f;
        [FieldAttr(40)] public float _wave1Amplitude = 12.0f;
        [FieldAttr(44)] public float _wave2Angle = 125.0f;
        [FieldAttr(48)] public float _wave2Length = 2670.0f;
        [FieldAttr(52)] public float _wave2Speed = 560.0f;
        [FieldAttr(56)] public float _wave2Amplitude = 12.0f;
        [FieldAttr(60)] public float _restingWaterHeightOffset;
        [FieldAttr(64)] public CWaypoint? _splash1Origin;
        [FieldAttr(72)] public float _splash1Length = 600.0f;
        [FieldAttr(76)] public float _splash1Speed = 690.0f;
        [FieldAttr(80)] public float _splash1Amplitude = 50.0f;
        [FieldAttr(84)] public float _splash1Radius = 6000.0f;
        [FieldAttr(88)] public CWaypoint? _splash2Origin;
        [FieldAttr(96)] public float _splash2Length = 600.0f;
        [FieldAttr(100)] public float _splash2Speed = 690.0f;
        [FieldAttr(104)] public float _splash2Amplitude = 50.0f;
        [FieldAttr(108)] public float _splash2Radius = 6000.0f;
        [FieldAttr(112)] public CWaypointList? _splashOriginList;
        [FieldAttr(120)] public bool _autoGenerateRandomSplashes;
        [FieldAttr(124)] public igRangedFloatMetaField _randomSplashLength = new();
        [FieldAttr(132)] public igRangedFloatMetaField _randomSplashSpeed = new();
        [FieldAttr(140)] public igRangedFloatMetaField _randomSplashAmplitude = new();
        [FieldAttr(148)] public igRangedFloatMetaField _randomSplashRadius = new();
        [FieldAttr(156)] public igRangedFloatMetaField _randomSplashDecreaseTime = new();
        [FieldAttr(164)] public bool _debug;
        [FieldAttr(168)] public igHandleMetaField _splashVfx = new();
    }
}
