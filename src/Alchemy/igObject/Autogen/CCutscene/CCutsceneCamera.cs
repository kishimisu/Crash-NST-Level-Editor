namespace Alchemy
{
    [ObjectAttr(512, 16)]
    public class CCutsceneCamera : CCamera
    {
        [FieldAttr(416)] public CCameraKeyframeAnimation? _animation;
        [FieldAttr(424)] public string? _motionPathFilename = null;
        [FieldAttr(432)] public igSpline? _spline;
        [FieldAttr(440)] public float _splineMoveSpeed = 320.0f;
        [FieldAttr(448)] public igHandleMetaField _attachToEntity = new();
        [FieldAttr(456)] public igVec3fMetaField _attachedEntityLocalOffset = new();
        [FieldAttr(468)] public igVec3fMetaField _attachedEntityLocalAngles = new();
        [FieldAttr(480)] public float _currentPositionOnSpline;
        [FieldAttr(488)] public igRawRefMetaField _motionPath = new();
        [FieldAttr(496)] public float _runningTime;
        [FieldAttr(500)] public float _dataPumpFloatBindForFOV;
        [FieldAttr(504)] public bool _isInternalAttachToEntity;
        [FieldAttr(508)] public uint _lastFrameUpdated;
    }
}
