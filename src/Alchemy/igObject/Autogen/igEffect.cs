namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igEffect : igNamedObject
    {
        [FieldAttr(24)] public igTechniqueList? _techniqueList;
        [FieldAttr(32)] public igObjectAnnotationTable? _annotations;
        [FieldAttr(40)] public igIntList? _globalTechniqueList;
        [FieldAttr(48)] public u64 _globalTechniqueMask;
    }
}
