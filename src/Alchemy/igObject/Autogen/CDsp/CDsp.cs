namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CDsp : igObject
    {
        [ObjectAttr(4)]
        public class PlatformEnabled : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _enabledOnAspen = true;
            [FieldAttr(1, size: 1)] public bool _enabledOnAspenLow;
            [FieldAttr(2, size: 1)] public bool _enabledOnDurango = false;
            [FieldAttr(3, size: 1)] public bool _enabledOnPS4 = false;
            [FieldAttr(4, size: 1)] public bool _enabledOnWindows = false;
        }

        [FieldAttr(16)] public EigDspType _type;
        [FieldAttr(24)] public igRawRefMetaField _dsp = new();
        [FieldAttr(32)] public PlatformEnabled _platformEnabled = new();
        [FieldAttr(36)] public bool _bypass;
        [FieldAttr(40)] public igHandleMetaField _override = new();
    }
}
