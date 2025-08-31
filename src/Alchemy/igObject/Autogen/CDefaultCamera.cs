namespace Alchemy
{
    [ObjectAttr(464, 16)]
    public class CDefaultCamera : CConstrainedCamera
    {
        [FieldAttr(432)] public float _rotationSpeed = 1.39999998f;
        [FieldAttr(436)] public float _radius = 1200.0f;
        [FieldAttr(440)] public igVec3fMetaField _directionFromLookAtPointToCamera = new();
        [FieldAttr(452)] public EPlayerId _playerId = EPlayerId.EPLAYERID_NONE;
    }
}
