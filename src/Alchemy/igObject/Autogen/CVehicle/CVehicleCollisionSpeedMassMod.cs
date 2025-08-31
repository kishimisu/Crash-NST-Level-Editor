namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class CVehicleCollisionSpeedMassMod : igObject
    {
        [FieldAttr(16)] public float _speedRatio;
        [FieldAttr(20)] public int _weightChange;
    }
}
