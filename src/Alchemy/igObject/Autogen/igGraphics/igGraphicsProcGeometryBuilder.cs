namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 104, align: 8)]
    public class igGraphicsProcGeometryBuilder : igProcGeometryBuilder
    {
        [FieldAttr(nst: 64, ctr: 64)] public igProcGeometryDrawCallDataPool[] _drawCallPool = new igProcGeometryDrawCallDataPool[2];
        [FieldAttr(nst: 80, ctr: 80)] public igDynamicBuffer? _procGeometryBuffer;
        [FieldAttr(nst: 88, ctr: 88)] public igSizeTypeMetaField _format = new();
        [FieldAttr(nst: 96, ctr: 96)] public bool _ownsPools = true;
    }
}
