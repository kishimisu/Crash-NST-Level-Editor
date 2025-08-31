namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CVehicleCollisionReactionData : igObject
    {
        [FieldAttr(16)] public int _weightDifferenceMax = 100;
        [FieldAttr(20)] public CVehicleSystemData.EVehicleCollisionReaction _reaction;
        [FieldAttr(24)] public int _damageAmount;
    }
}
