namespace Alchemy
{
    [ObjectAttr(64, 8, metaObject: true)]
    public class CEnableStack : igObject
    {
        public enum EEnableStackMode : uint
        {
            eESM_StartEnabled = 0,
            eESM_StartDisabled = 1,
        }

        [FieldAttr(16)] public igRawRefMetaField _dynamicFieldMemory = new();
        [FieldAttr(24)] public int _stackCounter;
        [FieldAttr(28)] public EEnableStackMode _mode;
        [FieldAttr(32)] public int _allowNegativeStackRequests;
        [FieldAttr(36)] public bool _enableMismatchedCallChecks = true;
        [FieldAttr(40)] public string? _enableErrorMessage = "RequestEnable() has been called more times than RequestDisable()";
        [FieldAttr(48)] public string? _disableErrorMessage = "RequestDisable() has been called more times than RequestEnable()";
        [FieldAttr(56, false)] public igMetaObject? _meta = (null);
    }
}
