namespace Alchemy
{
    [ObjectAttr(1376, 4)]
    public class CWindParameters2 : igObject
    {
        [FieldAttr(16)] public bool[] _options = new bool[31];
        [FieldAttr(48)] public float _strengthResponse = 5.0f;
        [FieldAttr(52)] public float _directionResponse = 2.5f;
        [FieldAttr(56)] public float _anchorOffset;
        [FieldAttr(60)] public float _anchorDistanceScale = 1.0f;
        [FieldAttr(64)] public float[] _frequencies = new float[100];
        [FieldAttr(464)] public float _globalHeight = 50.0f;
        [FieldAttr(468)] public float _globalHeightExponent = 2.0f;
        [FieldAttr(472)] public float[] _globalDistance = new float[10];
        [FieldAttr(512)] public float[] _globalDirectionAdherence = new float[10];
        [FieldAttr(552)] public SBranchLevelMetaField[] _branch = new SBranchLevelMetaField[1];
        [FieldAttr(816)] public float _rollingBranchesMaxScale = 1.0f;
        [FieldAttr(820)] public float _rollingBranchesMinScale = 1.0f;
        [FieldAttr(824)] public float _rollingBranchesSpeed = 0.3f;
        [FieldAttr(828)] public float _rollingBranchesRipple = 5.0f;
        [FieldAttr(832)] public float _maxBranchLevel1Length = 10.0f;
        [FieldAttr(836)] public igVec3fMetaField _branchWindAnchor = new();
        [FieldAttr(848)] public SLeafGroupMetaField[] _leaf = new SLeafGroupMetaField[1];
        [FieldAttr(1296)] public float[] _frondRippleDistance = new float[10];
        [FieldAttr(1336)] public float _frondRippleTile = 10.0f;
        [FieldAttr(1340)] public float _frondRippleLightingScalar = 1.0f;
        [FieldAttr(1344)] public float _gustFrequency;
        [FieldAttr(1348)] public float _gustStrengthMin = 0.5f;
        [FieldAttr(1352)] public float _gustStrengthMax = 1.0f;
        [FieldAttr(1356)] public float _gustDurationMin = 1.0f;
        [FieldAttr(1360)] public float _gustDurationMax = 4.0f;
        [FieldAttr(1364)] public float _gustRiseScalar = 1.0f;
        [FieldAttr(1368)] public float _gustFallScalar = 1.0f;
    }
}
