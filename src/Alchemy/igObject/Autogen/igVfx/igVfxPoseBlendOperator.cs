namespace Alchemy
{
    [ObjectAttr(120, 4)]
    public class igVfxPoseBlendOperator : igVfxOperator
    {
        [ObjectAttr(4)]
        public class BlendFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 4)] public EReferenceFrame _endpoint1 = EReferenceFrame.eRF_Track1;
            [FieldAttr(4, size: 4)] public EReferenceFrame _endpoint2 = EReferenceFrame.eRF_World;
            [FieldAttr(8, size: 1)] public bool _blendOrientation = false;
            [FieldAttr(9, size: 1)] public bool _blendPosition = false;
        }

        [FieldAttr(24)] public BlendFlags _blendFlags = new();
        [FieldAttr(28)] public igVfxRangedCurveMetaField _blend = new();
        [FieldAttr(112)] public EOperatorCurveInput _blendInput;
    }
}
