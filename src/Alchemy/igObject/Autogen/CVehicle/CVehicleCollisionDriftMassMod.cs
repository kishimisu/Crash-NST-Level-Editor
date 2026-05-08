namespace Alchemy
{
    [ObjectAttr(nst: 24, ctr: 24, align: 4)]
    public class CVehicleCollisionDriftMassMod : igObject
    {
        [FieldAttr(nst: 16, ctr: 12)] public int _weightChange;
        [FieldAttr(nst: 20, ctr: 16)] public float _driftDot = 1.0f;
    }
}
