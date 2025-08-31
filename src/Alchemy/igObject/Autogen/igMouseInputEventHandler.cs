namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igMouseInputEventHandler : igObject
    {
        [FieldAttr(16)] public igMouseInputEventHandler? _next;
        [FieldAttr(24)] public int _priority;
        [FieldAttr(32, false)] public igMouseInputDevice? _device;
        [FieldAttr(40)] public igRawRefMetaField _handler = new();
        [FieldAttr(48, false)] public igObject? _owner;
    }
}
