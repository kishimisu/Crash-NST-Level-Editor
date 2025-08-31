namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CVehicleVfxHandlerData : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _effect = new();
        [FieldAttr(24)] public CBoltPoint? _bolt1;
        [FieldAttr(32)] public CBoltPoint? _bolt2;
    }
}
