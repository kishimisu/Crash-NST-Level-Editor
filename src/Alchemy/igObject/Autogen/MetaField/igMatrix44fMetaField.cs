namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igMatrix44fMetaField : igMetaField
    {
        [FieldAttr(0)] public igVec4fMetaField _row0 = new();
        [FieldAttr(16)] public igVec4fMetaField _row1 = new();
        [FieldAttr(32)] public igVec4fMetaField _row2 = new();
        [FieldAttr(48)] public igVec4fMetaField _row3 = new();
    }
}
