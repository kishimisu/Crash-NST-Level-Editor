namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igMatrix44fMetaField : igMetaField
    {
        [FieldAttr(0)] public igVec4fMetaField _row0 = new(1, 0, 0, 0);
        [FieldAttr(16)] public igVec4fMetaField _row1 = new(0, 1, 0, 0);
        [FieldAttr(32)] public igVec4fMetaField _row2 = new(0, 0, 1, 0);
        [FieldAttr(48)] public igVec4fMetaField _row3 = new(0, 0, 0, 1);
    }
}
