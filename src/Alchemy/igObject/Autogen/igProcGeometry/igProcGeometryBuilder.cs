namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igProcGeometryBuilder : igObject
    {
        [FieldAttr(16)] public igVertexFormat? _vertexFormat;
        [FieldAttr(24)] public EIG_GFX_DRAW _primitiveType;
        [FieldAttr(28)] public uint _componentFlags;
        [FieldAttr(32)] public int[] _iteratorIndex = new int[8];
    }
}
