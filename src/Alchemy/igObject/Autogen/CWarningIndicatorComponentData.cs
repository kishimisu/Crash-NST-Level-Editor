namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CWarningIndicatorComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public igHandleMetaField _warningEffect = new();
        [FieldAttr(32)] public CBoltPoint? _warningEffectBolt;
        [FieldAttr(40)] public CQueryFilter? _filterTargets;
        [FieldAttr(48)] public float _filterTargetingAngleRange;
    }
}
