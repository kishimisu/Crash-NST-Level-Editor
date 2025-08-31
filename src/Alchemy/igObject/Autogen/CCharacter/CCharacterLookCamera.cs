namespace Alchemy
{
    [ObjectAttr(512, 16)]
    public class CCharacterLookCamera : CDefaultCamera
    {
        [FieldAttr(464)] public float _rotationRadius = 1200.0f;
        [FieldAttr(468)] public float _rotationSpeed_1 = 2.5f;
        [FieldAttr(472)] public float _targetElevation = 100.0f;
        [FieldAttr(476)] public float _cameraElevation = 125.0f;
        [FieldAttr(480)] public igVec3fMetaField _directionFromLookAtPointToCamera_1 = new();
        [FieldAttr(492)] public float _characterFollowRotationSmoothing = 0.1f;
        [FieldAttr(496)] public bool _isPlayerControlledRotationAllowed = true;
        [FieldAttr(497)] public bool _followCharacterIfNoPlayerInput = true;
    }
}
