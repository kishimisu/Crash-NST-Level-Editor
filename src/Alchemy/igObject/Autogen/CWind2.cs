namespace Alchemy
{
    [ObjectAttr(272, 16)]
    public class CWind2 : igObject
    {
        [FieldAttr(16)] public CWindParameters2? _params;
        [FieldAttr(24)] public igObject[] _windConstantBundles = new igObject[2];
        [FieldAttr(40)] public igModelData? _associatedModelData;
        [FieldAttr(48)] public igRandomMetaField _random = new();
        [FieldAttr(56)] public float _strength;
        [FieldAttr(60)] public igVec3fMetaField _direction = new();
        [FieldAttr(72)] public bool _allowGusting = true;
        [FieldAttr(76)] public float _currentTime;
        [FieldAttr(80)] public float _lastTime = -1.0f;
        [FieldAttr(84)] public float _elapsedTime;
        [FieldAttr(88)] public float _strengthTarget;
        [FieldAttr(92)] public float _strengthChangeStartTime;
        [FieldAttr(96)] public float _strengthChangeEndTime;
        [FieldAttr(100)] public float _strengthAtStart;
        [FieldAttr(104)] public igVec3fMetaField _directionTarget = new();
        [FieldAttr(116)] public igVec3fMetaField _directionAtStart = new();
        [FieldAttr(128)] public igVec3fMetaField _directionMidTarget = new();
        [FieldAttr(140)] public float _directionChangeStartTime;
        [FieldAttr(144)] public float _directionChangeEndTime;
        [FieldAttr(148)] public float _gust;
        [FieldAttr(152)] public float _gustTarget;
        [FieldAttr(156)] public float _gustRiseTarget;
        [FieldAttr(160)] public float _gustFallTarget;
        [FieldAttr(164)] public float _gustStart;
        [FieldAttr(168)] public float _gustAtStart = 1.0f;
        [FieldAttr(172)] public float _gustFallStart;
        [FieldAttr(176)] public float _combinedStrength;
        [FieldAttr(180)] public float[] _oscillationTimes = new float[10];
        [FieldAttr(224)] public igVec4fMetaField _windGlobal = new();
        [FieldAttr(240)] public igVec4fMetaField _windVector = new();
        [FieldAttr(256)] public float _globalDirectionAdherence;
        [FieldAttr(264)] public CWind2? _windLeader;
    }
}
