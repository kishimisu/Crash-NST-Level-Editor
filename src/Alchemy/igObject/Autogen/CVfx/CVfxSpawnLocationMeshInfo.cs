namespace Alchemy
{
    [ObjectAttr(nst: 112, ctr: 112, align: 8)]
    public class CVfxSpawnLocationMeshInfo : igInfo
    {
        [FieldAttr(nst: 40, ctr: 40)] public igVectorMetaField<igVec3fMetaField> _spawnPositions = new();
        [FieldAttr(nst: 64, ctr: 64)] public igVectorMetaField<igQuaternionfMetaField> _spawnOrientations = new();
        [FieldAttr(nst: 88, ctr: 88)] public igVectorMetaField<u16> _randomIndices = new();
    }
}
