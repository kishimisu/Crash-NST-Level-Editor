namespace Alchemy
{
    [ObjectAttr(440, 8)]
    public class CVfxDrawForceOperator : igVfxDrawOperator
    {
        [ObjectAttr(2)]
        public class SurfaceFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _spawnLayer1 = true;
            [FieldAttr(1, size: 1)] public bool _spawnLayer2 = false;
            [FieldAttr(2, size: 1)] public bool _spawnLayer3 = false;
            [FieldAttr(3, size: 1)] public bool _spawnLayer4 = false;
            [FieldAttr(4, size: 1)] public bool _spawnLayer5 = false;
            [FieldAttr(5, size: 1)] public bool _spawnLayer6 = false;
            [FieldAttr(6, size: 1)] public bool _spawnLayer7 = false;
            [FieldAttr(7, size: 1)] public bool _spawnLayer8 = false;
            [FieldAttr(8, size: 1)] public bool _spawnLayer9 = false;
            [FieldAttr(9, size: 1)] public bool _spawnLayer10 = false;
            [FieldAttr(10, size: 1)] public bool _spawnLayer11 = false;
            [FieldAttr(11, size: 1)] public bool _spawnLayer12 = false;
            [FieldAttr(12, size: 1)] public bool _spawnLayer13 = false;
            [FieldAttr(13, size: 1)] public bool _spawnLayer14 = false;
            [FieldAttr(14, size: 1)] public bool _spawnLayer15 = false;
            [FieldAttr(15, size: 1)] public bool _spawnLayer16 = false;
        }

        [FieldAttr(32)] public EDrawForceCoordinateSystem _coordinateSystem;
        [FieldAttr(36)] public EDrawForceShapeType _shapeType;
        [FieldAttr(40)] public igVfxRangedCurveMetaField _magnitudeT = new();
        [FieldAttr(124)] public EOperatorCurveInput _magnitudeInput;
        [FieldAttr(128)] public igVfxRangedCurveMetaField _magnitudeA = new();
        [FieldAttr(212)] public igVfxRangedCurveMetaField _magnitudeB = new();
        [FieldAttr(296)] public igVfxRangedCurveMetaField _magnitudeC = new();
        [FieldAttr(380)] public uint _collisionFlags = 64;
        [FieldAttr(384)] public SurfaceFlags _surfaceFlags = new();
        [FieldAttr(388)] public float _tumbleFraction;
        [FieldAttr(392)] public float _massFactor = 1.0f;
        [FieldAttr(396)] public float _maxLinearSpeed = -1.0f;
        [FieldAttr(400)] public float _maxAngularSpeed = -1.0f;
        [FieldAttr(404)] public bool _impulse;
        [FieldAttr(405)] public bool _ignoreBoltEntity;
        [FieldAttr(408)] public EDrawForceRangeCorrelation _rangeCorrelation;
        [FieldAttr(412)] public u32 /* igStructMetaField */ _instance;
        [FieldAttr(416)] public CHavokShapeMetaField _cachedShape = new();
        [FieldAttr(424)] public igVec3fMetaField _cachedShapeBounds = new();
    }
}
