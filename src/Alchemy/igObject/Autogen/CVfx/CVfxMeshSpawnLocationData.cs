namespace Alchemy
{
    [ObjectAttr(nst: 112, ctr: 104, align: 8)]
    public class CVfxMeshSpawnLocationData : igVfxSpawnLocationData
    {
        public enum ESpawnOrderMethod
        {
            kShuffled = 0,
            kRandom = 1,
        }

        [FieldAttr(nst: 72, ctr: 64)] public string? _meshName = null;
        [FieldAttr(nst: 80, ctr: 72)] public ESpawnOrderMethod _spawnOrder;
        [FieldAttr(nst: 84, ctr: 76)] public igVec3fMetaField _meshScale = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _spawnMesh = new();
        [FieldAttr(nst: 104, ctr: 96)] public bool _applyNormals;
        [FieldAttr(nst: 105, ctr: 97)] public bool _shouldRefreshMesh;
    }
}
