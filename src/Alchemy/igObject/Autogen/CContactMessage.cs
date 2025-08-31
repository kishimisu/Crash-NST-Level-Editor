namespace Alchemy
{
    [ObjectAttr(72, 8, metaType: typeof(CContactMessage))]
    public class CContactMessage : CEntityMessage
    {
        [FieldAttr(56, false)] public CNovaCollisionInfo? _contact;
        [FieldAttr(64)] public igRawRefMetaField _collision = new();
    }
}
