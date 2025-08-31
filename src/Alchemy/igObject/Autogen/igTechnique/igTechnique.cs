namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igTechnique : igNamedObject
    {
        [FieldAttr(24)] public igCachedAttrList? _attrs;
        [FieldAttr(32)] public igTechniqueParameterList? _parameterList;
        [FieldAttr(40)] public igTechniqueSamplerList? _samplerList;
        [FieldAttr(48)] public igTechniqueVertexComponentList? _vertexComponents;
        [FieldAttr(56)] public int _appFlags;
    }
}
