namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CBehaviorGraphReflectionDataEntry : igObject
    {
        [FieldAttr(16)] public CBehaviorGraphReflectionData? _reflectionData;
        [FieldAttr(24)] public string? _filename = null;
    }
}
