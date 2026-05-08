namespace Alchemy
{
    [ObjectAttr(nst: 288, ctr: 288, align: 16)]
    public class CCloudInstance : igObject
    {
        [FieldAttr(nst: 16, ctr: 16)] public igSizeTypeMetaField[] _indexResources = new igSizeTypeMetaField[12];
        [FieldAttr(nst: 112, ctr: 112)] public igModelDrawCallData? _drawCallData;
        [FieldAttr(nst: 120, ctr: 120)] public igModelDrawCallData? _originalDrawCallData;
        [FieldAttr(nst: 128, ctr: 128)] public igMatrix44fMetaField[] _transform = new igMatrix44fMetaField[2];
        [FieldAttr(nst: 256, ctr: 256)] public int _index;
        [FieldAttr(nst: 264, ctr: 264)] public igModelDrawCall? _drawCall;
        [FieldAttr(nst: 272, ctr: 272)] public int _lastDirection = -1;
    }
}
