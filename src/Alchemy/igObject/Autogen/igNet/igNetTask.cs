namespace Alchemy
{
    [ObjectAttr(144, 8)]
    public class igNetTask : igObject
    {
        [FieldAttr(16, false)] public igNetTaskQueue? _parentQueue;
        [FieldAttr(24, false)] public igNetTask? _parentTask;
        [FieldAttr(32)] public igRawRefMetaField _callingObject = new();
        [FieldAttr(40)] public u32 /* igStructMetaField */ _completionCallback;
        [FieldAttr(104)] public float _timeoutInSeconds;
        [FieldAttr(108)] public bool _timeoutElapsed;
        [FieldAttr(112)] public int _errorCode;
        [FieldAttr(116)] public bool _canceled;
        [FieldAttr(117)] public bool _terminateWhenCanceled = true;
        [FieldAttr(118)] public bool _autoPropagateErrors;
        [FieldAttr(120)] public string? _taskType = "NetworkTask";
        [FieldAttr(128)] public igRawRefMetaField _userParam = new();
        [FieldAttr(136)] public igTimeMetaField _taskStartTime = new();
    }
}
