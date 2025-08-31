namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igRenderPass : igNamedObject
    {
        [FieldAttr(24)] public bool _active;
        [FieldAttr(32)] public string? _passEventName = null;
        [FieldAttr(40)] public igRenderPassList? _children;
        [FieldAttr(48)] public u8 _totalChildCount;
        [FieldAttr(49)] public u8 _passId = 255;
    }
}
