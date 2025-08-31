namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class igVfxOperatorPrimitiveData : igVfxPrimitiveData
    {
        [ObjectAttr(4)]
        public class StackPrimitiveFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 2)] public ESortMode _sortMode;
            [FieldAttr(2, size: 1)] public bool _useSecondBolt;
            [FieldAttr(3, size: 1)] public bool _spawnByDistance;
            [FieldAttr(4, size: 7)] public int _totalStorageWords;
            [FieldAttr(11, size: 7)] public int _primitiveStorageWords;
            [FieldAttr(18, size: 5)] public int _procGeometryCount;
            [FieldAttr(23, size: 8)] public int _firstProcGeometryOperator;
            [FieldAttr(31, size: 1)] public bool _dirty;
        }

        [ObjectAttr(2)]
        public class StackPrimitiveFlags2 : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _needsPreUpdate;
            [FieldAttr(1, size: 1)] public bool _needsPostUpdate;
            [FieldAttr(2, size: 1)] public bool _needsPauseResume;
            [FieldAttr(3, size: 1)] public bool _needsHasInstances;
            [FieldAttr(4, size: 1)] public bool _needsLateUpdate;
            [FieldAttr(5, size: 1)] public bool _supportsInstancePositionalData;
            [FieldAttr(6, size: 1)] public bool _needsActivateApply;
            [FieldAttr(7, size: 1)] public bool _needsDeactivateApply;
            [FieldAttr(8, size: 1)] public bool _needsGroundBolt;
        }

        [ObjectAttr(2)]
        public class ZeroSpaceFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 4)] public EReferenceFrame _track0ZeroSpace = EReferenceFrame.eRF_Bolt1;
            [FieldAttr(4, size: 4)] public EReferenceFrame _track1ZeroSpace = EReferenceFrame.eRF_World;
            [FieldAttr(8, size: 4)] public EReferenceFrame _track2ZeroSpace = EReferenceFrame.eRF_World;
            [FieldAttr(12, size: 4)] public EReferenceFrame _track3ZeroSpace = EReferenceFrame.eRF_World;
        }

        [ObjectAttr(4)]
        public class LocationSpaceFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 4)] public EReferenceFrame _track0OrientationSpace;
            [FieldAttr(4, size: 4)] public EReferenceFrame _track1OrientationSpace;
            [FieldAttr(8, size: 4)] public EReferenceFrame _track2OrientationSpace;
            [FieldAttr(12, size: 4)] public EReferenceFrame _track3OrientationSpace;
            [FieldAttr(16, size: 4)] public EReferenceFrame _track0PositionSpace;
            [FieldAttr(20, size: 4)] public EReferenceFrame _track1PositionSpace;
            [FieldAttr(24, size: 4)] public EReferenceFrame _track2PositionSpace;
            [FieldAttr(28, size: 4)] public EReferenceFrame _track3PositionSpace;
        }

        [ObjectAttr(4)]
        public class MotionSpaceFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 4)] public EReferenceFrame _track0SpinSpace;
            [FieldAttr(4, size: 4)] public EReferenceFrame _track1SpinSpace;
            [FieldAttr(8, size: 4)] public EReferenceFrame _track2SpinSpace;
            [FieldAttr(12, size: 4)] public EReferenceFrame _track3SpinSpace;
            [FieldAttr(16, size: 4)] public EReferenceFrame _track0VelocitySpace;
            [FieldAttr(20, size: 4)] public EReferenceFrame _track1VelocitySpace;
            [FieldAttr(24, size: 4)] public EReferenceFrame _track2VelocitySpace;
            [FieldAttr(28, size: 4)] public EReferenceFrame _track3VelocitySpace;
        }

        [FieldAttr(56)] public StackPrimitiveFlags _stackPrimitiveFlags = new();
        [FieldAttr(60)] public StackPrimitiveFlags2 _stackPrimitiveFlags2 = new();
        [FieldAttr(62)] public ZeroSpaceFlags _zeroSpaceFlags = new();
        [FieldAttr(64)] public LocationSpaceFlags _locationSpaceFlags = new();
        [FieldAttr(68)] public MotionSpaceFlags _motionSpaceFlags = new();
        [FieldAttr(72)] public u8[] _spawnZeroFlags = new u8[4];
        [FieldAttr(76)] public u8[] _spawnStoreUpdateLoadFlags = new u8[4];
        [FieldAttr(80)] public u8[] _updateZeroFlags = new u8[4];
        [FieldAttr(84)] public u8[] _updateStoreFlags = new u8[4];
        [FieldAttr(88)] public u8[] _combinedLivenessFlags = new u8[4];
        [FieldAttr(92)] public u8[] _trackStorageOffsetWords = new u8[4];
        [FieldAttr(96)] public igVfxStackOperatorList? _spawnStack;
        [FieldAttr(104)] public igVfxStackOperatorList? _updateStack;
    }
}
