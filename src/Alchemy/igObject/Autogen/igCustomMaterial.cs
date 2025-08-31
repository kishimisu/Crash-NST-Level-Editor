namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igCustomMaterial : igMaterial
    {
        [ObjectAttr(4)]
        public class CustomMaterialBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 3)] public EIG_GFX_ALPHA_FUNCTION _alphaFunction = EIG_GFX_ALPHA_FUNCTION.GEQUAL;
            [FieldAttr(3, size: 1)] public bool _alphaTestState;
            [FieldAttr(4, size: 4)] public EIG_GFX_BLENDING_FUNCTION _blendingSource = EIG_GFX_BLENDING_FUNCTION.ZERO;
            [FieldAttr(8, size: 4)] public EIG_GFX_BLENDING_FUNCTION _blendingDestination = EIG_GFX_BLENDING_FUNCTION.ZERO;
            [FieldAttr(12, size: 3)] public EIG_GFX_BLENDING_EQUATION _blendingEquation;
            [FieldAttr(15, size: 1)] public bool _blendingState;
            [FieldAttr(16, size: 1)] public EIG_GFX_CULL_FACE_MODE _cullFaceMode;
            [FieldAttr(17, size: 1)] public bool _cullFaceState = false;
            [FieldAttr(18, size: 1)] public bool _depthTestState = false;
            [FieldAttr(19, size: 1)] public bool _depthWriteState = false;
            [FieldAttr(20, size: 3)] public EIG_GFX_TEXTURE_WRAP _wrapS = EIG_GFX_TEXTURE_WRAP.CLAMP;
            [FieldAttr(23, size: 3)] public EIG_GFX_TEXTURE_WRAP _wrapT = EIG_GFX_TEXTURE_WRAP.CLAMP;
            [FieldAttr(26, size: 4)] public u8 _sortKey = 0;
            [FieldAttr(30, size: 1)] public bool _prepareAffectsRenderState = false;
        }

        [ObjectAttr(2)]
        public class CustomMaterialBitfield2 : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _dirty = true;
            [FieldAttr(1, size: 4)] public EIG_GFX_TEXTURE_FILTER _magnificationFilter = EIG_GFX_TEXTURE_FILTER.NEAREST;
            [FieldAttr(5, size: 4)] public EIG_GFX_TEXTURE_FILTER _minificationFilter = EIG_GFX_TEXTURE_FILTER.NEAREST;
            [FieldAttr(9, size: 2)] public EigCustomMaterialAnimationTimeSource _timeSource;
        }

        [ObjectAttr(2)]
        public class CustomMaterialPreparedBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _useDefaultAlphaFunctionAttr;
            [FieldAttr(1, size: 1)] public bool _useDefaultAlphaStateAttr;
            [FieldAttr(2, size: 1)] public bool _useDefaultBlendFunctionAttr;
            [FieldAttr(3, size: 1)] public bool _useDefaultBlendStateAttr;
            [FieldAttr(4, size: 1)] public bool _useDefaultCullFaceAttr;
            [FieldAttr(5, size: 1)] public bool _useDefaultDecalAttr;
            [FieldAttr(6, size: 1)] public bool _useDefaultDepthStateAttr;
            [FieldAttr(7, size: 1)] public bool _useDefaultDepthWriteStateAttr;
        }

        [FieldAttr(24)] public igCustomMaterialAnimationList? _transforms;
        [FieldAttr(32)] public CustomMaterialBitfield _customMaterialBitfield = new();
        [FieldAttr(36)] public CustomMaterialBitfield2 _customMaterialBitfield2 = new();
        [FieldAttr(38)] public CustomMaterialPreparedBitfield _customMaterialPreparedBitfield = new();
        [FieldAttr(40)] public float _alphaRefValue = 0.5f;
        [FieldAttr(44)] public float _depthBias;
        [FieldAttr(48)] public float _slopeScaleDepthBias;
        [FieldAttr(56)] public igAttrList? _renderState;
    }
}
