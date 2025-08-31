namespace Alchemy
{
    [ObjectAttr(592, 16)]
    public class igVfxDrawTrailOperator : igVfxDrawProcGeometryOperator
    {
        public enum ERolloutMethod : uint
        {
            kDrag = 0,
            kStretch = 1,
            kWipe = 2,
            kRoll = 3,
        }

        [ObjectAttr(4)]
        public class TrailFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 3)] public EModulation _widthAlongTrailModulation = EModulation.kModulate;
            [FieldAttr(3, size: 3)] public EModulation _colorAlongTrailModulation = EModulation.kReplace;
            [FieldAttr(6, size: 3)] public EModulation _alphaAlongTrailModulation = EModulation.kReplace;
            [FieldAttr(9, size: 3)] public igVfxDrawTrailOperator.ERolloutMethod _rolloutMethod;
            [FieldAttr(12, size: 3)] public int _trailBezier = 0;
            [FieldAttr(15, size: 6)] public int _trailSegmentCount = 0;
            [FieldAttr(21, size: 1)] public bool _banner;
            [FieldAttr(22, size: 1)] public bool _forceExactLength = false;
            [FieldAttr(23, size: 1)] public bool _isBillboard;
        }

        [FieldAttr(80)] public TrailFlags _trailFlags = new();
        [FieldAttr(84)] public u32 /* igStructMetaField */ _instanceData;
        [FieldAttr(88)] public igRangedFloatMetaField _trailLength = new();
        [FieldAttr(96)] public igVfxRangedCurveMetaField _widthAlongTrail = new();
        [FieldAttr(192)] public igVfxRgbCurveMetaField _colorAlongTrail = new();
        [FieldAttr(464)] public igVfxRangedCurveMetaField _alphaAlongTrail = new();
        [FieldAttr(560)] public igVec3fAlignedMetaField _sideAxis = new();
        [FieldAttr(576)] public EReferenceFrame _frame;
    }
}
