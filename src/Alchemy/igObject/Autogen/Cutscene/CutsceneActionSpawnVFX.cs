namespace Alchemy
{
    [ObjectAttr(104, 8)]
    public class CutsceneActionSpawnVFX : CutsceneVFXAction
    {
        [FieldAttr(40)] public igHandleMetaField _effect = new();
        [FieldAttr(48)] public igVec3fMetaField _position = new();
        [FieldAttr(60)] public igVec3fMetaField _angles = new();
        [FieldAttr(72)] public float _scale;
        [FieldAttr(80)] public igHandleMetaField _boltPoint = new();
        [FieldAttr(88)] public igHandleMetaField _boltPoint2 = new();
        [FieldAttr(96)] public igHandleMetaField _boltOwner2 = new();
    }
}
