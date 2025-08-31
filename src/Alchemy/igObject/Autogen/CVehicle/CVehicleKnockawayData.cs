namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CVehicleKnockawayData : igObject
    {
        [FieldAttr(16)] public float _knockawayForce = 3.0f;
        [FieldAttr(20)] public float _knockawayDuration = 0.1f;
        [FieldAttr(24)] public float _knockawayMaxSpeed = 1000.0f;
    }
}
