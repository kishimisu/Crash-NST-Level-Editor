namespace Alchemy
{
    [ObjectAttr(20)]
    public class igVfxModulationHelper : igMetaField
    {
		public enum ModulationType : byte
		{
			kModulationNone = 0,
			kModulationPoint = 1,
			kModulationLinear = 2,
			kModulationSmooth = 3,
			kModulationWhite = 4,
			kModulationSin = 5,
			kModulationRampUp = 6,
			kModulationRampDown = 7,
			kModulationTriangle = 8
		}

        [FieldAttr(0)] public float _mixAmount;
		[FieldAttr(4)] public float _phaseOffset;
		[FieldAttr(8)] public float _distributionArgument;
		[FieldAttr(12)] public float _modulationCycles;
		[FieldAttr(16)] public ushort _modulationCyclesInt;
		[FieldAttr(18)] public bool _hasModulation;
		[FieldAttr(19)] public byte _flags;

        public ModulationType _modulationType => (ModulationType)(_flags & 0x0F);
    }

    [ObjectAttr(272, 8)]
    public class igVfxRgbCurveMetaField : igMetaField
    {
        [FieldAttr(0)]   public bool _isConstant; // single color
        [FieldAttr(1)]   public byte _randomChannelMask; // bit0: R, bit1: G, bit2: B
        [FieldAttr(4)]   public igVfxModulationHelper _modulationHelper = new();

        [FieldAttr(32)]  public igVec4fMetaField _offsets; // offsets (gradient mode), color A (constant mode)
        [FieldAttr(48)]  public igVec4fMetaField _scales; // scales (gradient mode), color B (constant mode)
        [FieldAttr(64)]  public igVec4fMetaField _endTimes; // -1: unused

        [FieldAttr(80)]  public igVec4fMetaField _redValues;
        [FieldAttr(96)]  public igVec4fMetaField _redDeltas;
        [FieldAttr(112)] public igVec4fMetaField _redValuesRandom;
        [FieldAttr(128)] public igVec4fMetaField _redDeltasRandom;

        [FieldAttr(144)] public igVec4fMetaField _greenValues;
        [FieldAttr(160)] public igVec4fMetaField _greenDeltas;
        [FieldAttr(176)] public igVec4fMetaField _greenValuesRandom;
        [FieldAttr(192)] public igVec4fMetaField _greenDeltasRandom;

        [FieldAttr(208)] public igVec4fMetaField _blueValues;
        [FieldAttr(224)] public igVec4fMetaField _blueDeltas;
        [FieldAttr(240)] public igVec4fMetaField _blueValuesRandom;
        [FieldAttr(256)] public igVec4fMetaField _blueDeltasRandom;
    }
}
