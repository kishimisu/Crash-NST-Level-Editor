namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 88, align: 8)]
    public class CAttachmentSplineAttachment : igObject
    {
        [FieldAttr(nst: 16, ctr: 16)] public igEntity? _entityToSpawn;
        [FieldAttr(nst: 24, ctr: 24)] public igHandleMetaField _spawnSound = new();
        [FieldAttr(nst: 32, ctr: 32)] public igHandleMetaField _vfx = new();
        [FieldAttr(nst: 40, ctr: 40)] public CBoltPoint? _vfxBoltPoint;
        [FieldAttr(nst: 48, ctr: 48)] public float _distanceAheadOfPoint;
        [FieldAttr(nst: 52, ctr: 52)] public float _verticalOffset;
        [FieldAttr(nst: 56, ctr: 56)] public float _horizontalOffset;
        [FieldAttr(nst: 60, ctr: 60)] public float _rotationAroundSpline;
        [FieldAttr(nst: 64, ctr: 64)] public bool _initialized;
        [FieldAttr(nst: 65, ctr: 65)] public bool _spawned;
        [FieldAttr(nst: 68, ctr: 68)] public float _distanceAlongSpline;
        [FieldAttr(nst: 72, ctr: 72)] public igHandleMetaField _spawnedObject = new();
        [FieldAttr(nst: 80, ctr: 80)] public igVfxSpawnedEffectHandleList? _spawnedVfxList;
    }
}
