namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class igAABox : igVolume
    {
        [FieldAttr(16)] public igVec3fMetaField _min = new();
        [FieldAttr(28)] public igVec3fMetaField _max = new();
    }
}
