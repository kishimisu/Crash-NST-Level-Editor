namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CAudioGraphDriverModeSurfaceAccelStage : igObject
    {
        [FieldAttr(16)] public float _duration;
        [FieldAttr(20)] public float _startGraphInput;
        [FieldAttr(24)] public float _endGraphInput;
        [FieldAttr(32)] public igHandleMetaField _activationOneShotSound = new();
    }
}
