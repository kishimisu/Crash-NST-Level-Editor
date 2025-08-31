namespace Alchemy
{
    [ObjectAttr(192, 16)]
    public class COcclusionBox : igObject
    {
        [ObjectAttr(4)]
        public class OcclusionFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _invertVisibility;
            [FieldAttr(1, size: 4)] public int _flags = 9;
            [FieldAttr(5, size: 1)] public bool _state = false;
        }

        [FieldAttr(16)] public igMatrix44fMetaField _inverseMatrix = new();
        [FieldAttr(80)] public igEntityHandleList? _entities;
        [FieldAttr(88)] public CGameEntityHandleList? _dynamicEntities;
        [FieldAttr(96)] public CGameEntityHandleList? _messageReceivingEntities;
        [FieldAttr(104)] public int[] _activeCount = new int[2];
        [FieldAttr(112)] public igVec3fMetaField _position = new();
        [FieldAttr(124)] public igVec3fMetaField _rotation = new();
        [FieldAttr(136)] public igVec3fMetaField _scale = new();
        [FieldAttr(148)] public igVec3fMetaField _min = new();
        [FieldAttr(160)] public igVec3fMetaField _max = new();
        [FieldAttr(172)] public OcclusionFlags _occlusionFlags = new();
        [FieldAttr(176)] public bool _inverseMatrixDirty = true;
    }
}
