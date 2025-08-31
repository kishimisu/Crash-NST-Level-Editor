namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CVehicleCollisionCriteriaComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CVehicleCollisionResponseCriteriaTable? _collisionResponseCriteria;
    }
}
