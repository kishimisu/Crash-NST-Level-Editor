namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class CClampToGroundComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public float _aboveOffset = 1000.0f;
        [FieldAttr(28)] public float _belowOffset = 1000.0f;
        [FieldAttr(32)] public float _zOffset;
        [FieldAttr(36)] public bool _runOnce;
    }
}
