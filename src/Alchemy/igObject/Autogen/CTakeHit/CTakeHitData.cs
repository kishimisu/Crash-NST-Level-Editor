namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CTakeHitData : igObject
    {
        [FieldAttr(16)] public float _pushBackDistance = 75.0f;
        [FieldAttr(20)] public float _pushBackTime = 0.25f;
        [FieldAttr(24)] public float _throwAngleRange = 90.0f;
    }
}
