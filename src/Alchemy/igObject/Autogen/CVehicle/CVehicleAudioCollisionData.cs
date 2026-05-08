namespace Alchemy
{
    [ObjectAttr(nst: 32, ctr: 32, align: 8)]
    public class CVehicleAudioCollisionData : igObject
    {
        [FieldAttr(nst: 16, ctr: 12)] public float _minImpactSpeed;
        [FieldAttr(nst: 20, ctr: 16)] public float _maxImpactSpeed;
        [FieldAttr(nst: 24, ctr: 24)] public igHandleMetaField _impactSound = new();
    }
}
