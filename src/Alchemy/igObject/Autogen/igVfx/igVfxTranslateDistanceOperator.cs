namespace Alchemy
{
    [ObjectAttr(64, 16)]
    public class igVfxTranslateDistanceOperator : igVfxFrameOperator
    {
        [FieldAttr(32)] public igVec3fAlignedMetaField _direction = new();
        [FieldAttr(48)] public float _distance;
    }
}
