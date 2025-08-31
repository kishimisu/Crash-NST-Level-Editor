namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CGuiKeyboardMenuList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<igEnumMetaField> _data = new();
    }
}
