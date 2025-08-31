namespace Alchemy
{
    [ObjectAttr(56, 4)]
    public class CNavMoverComponentData : CEntityComponentData
    {
        public enum ENavMoverMoveMethod : uint
        {
            eNMMM_ActorInput = 0,
            eNMMM_SetPosition = 1,
            eNMMM_SetVelocity = 2,
            eNMMM_None = 3,
        }

        [ObjectAttr(4)]
        public class BitfieldStorage : igBitFieldMetaField
        {
            [FieldAttr(0, size: 3)] public CNavMoverComponentData.ENavMoverMoveMethod _moveMethod;
            [FieldAttr(3, size: 1)] public bool _allowSpaceChanges;
            [FieldAttr(4, size: 1)] public bool _allowSeparationFromNavMesh;
            [FieldAttr(5, size: 5)] public uint _linkCapabilities;
            [FieldAttr(10, size: 10)] public uint _repulsorBlockageFlags = 15;
            [FieldAttr(20, size: 10)] public uint _repulsorIdentityFlags = 0;
            [FieldAttr(30, size: 2)] public uint _areaUsageFlags;
        }

        [FieldAttr(24)] public BitfieldStorage _bitfieldStorage = new();
        [FieldAttr(28)] public float _moverRadius;
        [FieldAttr(32)] public float _radiusCushion = 20.0f;
        [FieldAttr(36)] public float _stopDistance = 39.0f;
        [FieldAttr(40)] public float _earlyJumpDistance = 10.0f;
        [FieldAttr(44)] public float _pathSharingPenalty = 2.0f;
        [FieldAttr(48)] public float _maxPathSharingPenalty = 20.0f;
    }
}
