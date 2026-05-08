namespace Alchemy
{
    [ObjectAttr(nst: 40, ctr: 32, align: 8)]
    public class CCollectibleTracker : igObject
    {
        [FieldAttr(nst: 16, ctr: 12)] public u8 _maxCollectedCount = 1;
        [FieldAttr(nst: 17, ctr: 13)] public u8 _collectedCount;
        [FieldAttr(nst: 24, ctr: 16)] public CCollectibleTrackerEventDelegate? _onCollectibleTrackerCollected;
        [FieldAttr(nst: 32, ctr: 24)] public CCollectibleTrackerEventList? _onCollectibleTrackerCollectedEventList;
    }
}
