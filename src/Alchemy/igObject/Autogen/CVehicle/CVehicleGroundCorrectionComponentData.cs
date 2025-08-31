namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CVehicleGroundCorrectionComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public float _groundSpawnOffset = 150.0f;
    }
}
