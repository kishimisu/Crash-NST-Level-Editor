namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 96, align: 8)]
    public class CTrackTargetController : CBaseMovementController
    {
        public enum ETrackRepell
        {
            eTP_Attract = 0,
            eTP_Repell = 1,
        }

        [FieldAttr(nst: 56, ctr: 48)] public float _acceleration = 5.0f;
        [FieldAttr(nst: 60, ctr: 52)] public float _decceleration = 10.0f;
        [FieldAttr(nst: 64, ctr: 56)] public float _maxSpeed = 20.0f;
        [FieldAttr(nst: 68, ctr: 60)] public igVec3fMetaField _currentVelocity = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _target = new();
        [FieldAttr(nst: 88, ctr: 80)] public ETrackRepell _tracking;
        [FieldAttr(nst: 92, ctr: 84)] public igVec3fMetaField _offset = new();
    }
}
