namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Hint_DisplayData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _String = null;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Localized_String_List = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
        [FieldAttr(nst: 60, ctr: 52)] public float _Float_0x3c;
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool;
    }
}
