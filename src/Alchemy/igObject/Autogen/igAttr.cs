namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class igAttr : igObject
    {
        [FieldAttr(16)] public i16 _cachedUnitID;
        [FieldAttr(18)] public i16 _cachedAttrIndex = -1;
        [FieldAttr(20)] public bool _readOnlyCopy;
    }
}
