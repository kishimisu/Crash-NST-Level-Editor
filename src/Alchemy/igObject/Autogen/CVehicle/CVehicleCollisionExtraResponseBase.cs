namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CVehicleCollisionExtraResponseBase : igObject
    {
        public enum EDamageScalingMethod : uint
        {
            eDSM_None = 0,
            eDSM_ScaleByWeight = 1,
            eDSM_ScaleByModifiedWeight = 2,
        }

        [FieldAttr(16)] public CDamageData? _damage;
        [FieldAttr(24)] public EDamageScalingMethod _damageScaling;
    }
}
