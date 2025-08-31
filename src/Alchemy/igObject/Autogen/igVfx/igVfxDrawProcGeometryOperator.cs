namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igVfxDrawProcGeometryOperator : igVfxDrawTexturedOperator
    {
        [ObjectAttr(4)]
        public class DrawProcGeomFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _useUniqueGeometry;
            [FieldAttr(1, size: 8)] public int _nextProcGeometryOperator;
            [FieldAttr(9, size: 4)] public int _procGeometryOperatorIndex;
            [FieldAttr(13, size: 10)] public int _vertexCost;
        }

        [FieldAttr(72)] public DrawProcGeomFlags _drawProcGeomFlags = new();
    }
}
