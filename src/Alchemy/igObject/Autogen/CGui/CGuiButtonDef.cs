namespace Alchemy
{
    [ObjectAttr(nst: 200, ctr: 192, align: 8)]
    public class CGuiButtonDef : igGuiListItem
    {
        [FieldAttr(nst: 136)] public string? _label_1 = null;
        [FieldAttr(ctr: 128)] public string? _label2;
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _iconBase = new();
        [FieldAttr(nst: 152, ctr: 144)] public igHandleMetaField _iconBaseAdditive = new();
        [FieldAttr(nst: 160, ctr: 152)] public igHandleMetaField _icon = new();
        [FieldAttr(nst: 168, ctr: 160)] public int _category;
        [FieldAttr(nst: 172, ctr: 164)] public int _id;
        [FieldAttr(nst: 176, ctr: 168)] public int _param;
        [FieldAttr(nst: 180, ctr: 172)] public int _paramExtra;
        [FieldAttr(nst: 184, ctr: 176)] public int _attention;
        [FieldAttr(nst: 188, ctr: 180)] public int _status;
        [FieldAttr(nst: 192, ctr: 184)] public bool _enableRandom;
    }
}
