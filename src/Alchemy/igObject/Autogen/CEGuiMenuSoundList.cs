namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CEGuiMenuSoundList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<igEnumMetaField> _data = new();
    }
}
