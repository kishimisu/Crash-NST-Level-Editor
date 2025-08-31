namespace Alchemy
{
    [ObjectAttr(464, 16)]
    public class CStackCamera : CCamera
    {
        [FieldAttr(416)] public CStackCameraControllerList? _defaultCameraControllers;
        [FieldAttr(424)] public float _distanceOfTeleportThatCausesReset = 200.0f;
        [FieldAttr(428)] public EPlayerId _playerId;
        [FieldAttr(432)] public CStackCameraControllerList? _currentCameraControllers;
        [FieldAttr(440)] public CBlackboard? _blackboard;
        [FieldAttr(448)] public CChangeRequest? _disableZoom;
    }
}
