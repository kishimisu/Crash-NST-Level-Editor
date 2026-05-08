namespace Alchemy
{
    [ObjectAttr(nst: 80, align: 8)]
    public class igFileWorkItemProcessor : igObject
    {
        [FieldAttr(nst: 16)] public igFileWorkItemList? _workList;
        [FieldAttr(nst: 24)] public igThreadList? _threadList;
        [FieldAttr(nst: 32)] public igSemaphore? _workListLock;
        [FieldAttr(nst: 40)] public igSemaphore? _workPending;
        [FieldAttr(nst: 48)] public igFileWorkItemProcessor? _nextProcessor;
        [FieldAttr(nst: 56)] public bool _workerThreadsActive;
        [FieldAttr(nst: 57)] public bool _allowPause = true;
        [FieldAttr(nst: 64)] public igSignal? _pauseSignal;
        [FieldAttr(nst: 72)] public int _pauseCounter;
    }
}
