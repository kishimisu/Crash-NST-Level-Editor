namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class CGroundDetectorComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public uint _unsupportedFrames = 5;
        [FieldAttr(28)] public uint _unsupportedFramesWhileMovingUp = 2;
        [FieldAttr(32)] public float _upwardVelocityThreshold = 100.0f;
    }
}
