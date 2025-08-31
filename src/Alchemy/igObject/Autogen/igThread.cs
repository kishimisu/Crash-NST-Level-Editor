namespace Alchemy
{
    [ObjectAttr(120, 8)]
    public class igThread : igNamedObject
    {
        public enum EPriority : uint
        {
            kLow = 50,
            kNormal = 128,
            kHigh = 200,
            kUrgent = 255,
        }

        [FieldAttr(24)] public EPriority _priority = igThread.EPriority.kNormal;
        [FieldAttr(28)] public bool _active;
        [FieldAttr(32)] public igRawRefMetaField _arg = new();
        [FieldAttr(40)] public uint _stackSize = 16384;
        [FieldAttr(48)] public igRawRefMetaField _function = new();
        [FieldAttr(56)] public bool _isMaster;
        [FieldAttr(64)] public igVectorMetaField<igObject> _threadLocalObjects = new();
        [FieldAttr(88)] public int _hardwareThread = -2;
        [FieldAttr(96)] public igRawRefMetaField _result = new();
        [FieldAttr(104)] public igRawRefMetaField _threadHandle = new();
        [FieldAttr(112)] public uint _threadID;
    }
}
