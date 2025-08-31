namespace Alchemy
{
    [ObjectAttr(48, 4)]
    public class CNavRepulsorComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public float _repulsionRadius;
        [FieldAttr(28)] public float _outerCushion = 20.0f;
        [FieldAttr(32)] public float _innerCushion = 20.0f;
        [FieldAttr(36)] public float _repulsionMultiplier = 1.0f;
        [FieldAttr(40)] public uint _identityFlags = 1;
    }
}
