namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CDriftData : igObject
    {
        [FieldAttr(16)] public float _turningLookAheadTime = 0.05f;
        [FieldAttr(24)] public CVehicleBoostData? _driftBoostLevel2;
        [FieldAttr(32)] public CVehicleBoostData? _driftBoostLevel3;
        [FieldAttr(40)] public igHandleMetaField _vfxToSpawn = new();
        [FieldAttr(48)] public CBoltPoint? _boltPoint1;
        [FieldAttr(56)] public CBoltPoint? _boltPoint2;
        [FieldAttr(64)] public bool _dirty;
    }
}
