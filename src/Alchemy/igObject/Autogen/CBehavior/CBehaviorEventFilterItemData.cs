namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CBehaviorEventFilterItemData : igObject
    {
        public enum EFilterType : uint
        {
            eFT_RemoveEvents = 0,
            eFT_KeepEvents = 1,
        }

        [FieldAttr(16)] public igStringIntHashTable? _triggerEvents;
        [FieldAttr(24)] public igStringIntHashTable? _eventsToFilter;
        [FieldAttr(32)] public EFilterType _filterType;
    }
}
