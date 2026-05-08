namespace Alchemy
{
    [ObjectAttr(nst: 192, ctr: 224, align: 16)]
    public class CStreamingLevelAreaData : igObject
    {
        [FieldAttr(nst: 16, ctr: 12)] public igVec3fMetaField _position = new();
        [FieldAttr(nst: 28, ctr: 24)] public igVec3fMetaField _rotation = new();
        [FieldAttr(nst: 40, ctr: 36)] public igVec3fMetaField _scale = new();
        [FieldAttr(nst: 52, ctr: 48)] public igVec3fMetaField _min = new();
        [FieldAttr(nst: 64, ctr: 60)] public igVec3fMetaField _max = new();
        [FieldAttr(nst: 80, ctr: 72)] public CLevelChunkInfoHandleList? _chunks;
        [FieldAttr(nst: 88, ctr: 80)] public CLevelChunkInfoHandleList? _neighbors;
        [FieldAttr(ctr: 88)] public CLevelChunkInfoHandleList? _precacheChunks;
        [FieldAttr(ctr: 96)] public int _priority;
        [FieldAttr(ctr: 104)] public igStringRefList? _chunksToSpawn;
        [FieldAttr(nst: 96, ctr: 112)] public igStringRefList? _chunksToLoad;
        [FieldAttr(ctr: 120)] public igStringRefList? _chunksToPrecache;
        [FieldAttr(ctr: 128)] public igStringRefList? _allChunks;
        [FieldAttr(nst: 112, ctr: 144)] public igMatrix44fMetaField _inverseMatrix = new();
        [FieldAttr(nst: 176, ctr: 208)] public bool _inverseMatrixDirty = true;
    }
}
