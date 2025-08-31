namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CModelComponentData : igComponentData
    {
        [FieldAttr(24)] public string? _fileName = null;
        [FieldAttr(32)] public float _fadeFx = 1.0f;
        [FieldAttr(36)] public igModelInstance.EDistanceCullImportance _distanceCullImportance = igModelInstance.EDistanceCullImportance.kMedium;
    }
}
