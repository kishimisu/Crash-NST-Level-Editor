namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CAudioGraphDriverModeSurfaceReverse : CAudioGraphDriverMode
    {
        [FieldAttr(56)] public float _noSpeedGraphInput;
        [FieldAttr(60)] public float _maxSpeedGraphInput = 0.5f;
    }
}
