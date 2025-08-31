namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igNetTaskQueue : igObject
    {
        public enum EState : uint
        {
            kQueueIdle = 0,
            kQueueProcessingTask = 1,
        }

        [FieldAttr(16)] public igNetTaskList? _taskList;
        [FieldAttr(24)] public EState _state;
        [FieldAttr(32)] public igNetTask? _currentTask;
        [FieldAttr(40)] public igMutex? _lock;
    }
}
