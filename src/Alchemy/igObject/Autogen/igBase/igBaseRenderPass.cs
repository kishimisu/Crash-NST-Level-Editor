namespace Alchemy
{
    [ObjectAttr(352, 16)]
    public class igBaseRenderPass : igRenderPass
    {
        [FieldAttr(56)] public igRenderTargetInputDataList? _inputRenderTargetData;
        [FieldAttr(64)] public igImageInputDataList? _inputImageData;
        [FieldAttr(72)] public igRenderTargetOutputData? _outputRenderTargetData;
        [FieldAttr(80)] public igRenderTargetCustomDataList? _customRenderTargetData;
        [FieldAttr(88)] public igAttrList? _defaultRenderState;
        [FieldAttr(96)] public igShaderConstantBundleList? _shaderConstantBundles;
        [FieldAttr(104)] public int _dynamicConstantBundleCount;
        [FieldAttr(112)] public igGraphicsObjectList? _defaultRenderStateObjects;
        [FieldAttr(120)] public igMemoryCommandStream? _defaultRenderStateStream;
        [FieldAttr(128)] public igGraphicsObjectList? _overrideRenderStateObjects;
        [FieldAttr(136)] public igMemoryCommandStream? _overrideRenderStateStream;
        [FieldAttr(144)] public igSortKeyCommandDelegateObject? _postPassDelegate;
        [FieldAttr(152)] public igAttrList? _overrideRenderState;
        [FieldAttr(160)] public uint _clearMode;
        [FieldAttr(176)] public igVec4fMetaField _clearColor = new();
        [FieldAttr(192)] public float _clearDepth = 1.0f;
        [FieldAttr(196)] public uint _clearStencil;
        [FieldAttr(200)] public EIG_GFX_HISTENCIL_CLEAR _clearHiStencil = EIG_GFX_HISTENCIL_CLEAR.PASS;
        [FieldAttr(208)] public string? _cameraName = "main";
        [FieldAttr(216)] public bool _updateProjectionOnSizeChange = true;
        [FieldAttr(217)] public bool _updateViewportOnSizeChange = true;
        [FieldAttr(224)] public igHandleMetaField _material = new();
        [FieldAttr(232)] public bool _overrideMaterial = true;
        [FieldAttr(240)] public string? _preferredMaterialTechniqueName = null;
        [FieldAttr(248)] public int _preferredMaterialTechniqueGlobalIndex = -1;
        [FieldAttr(252)] public bool _useDefaultMaterialTechnique = true;
        [FieldAttr(253)] public bool _useDistanceCull;
        [FieldAttr(256)] public float _nearZ;
        [FieldAttr(260)] public float _farZ = 1.0f;
        [FieldAttr(264)] public bool _flushHiZStencil;
        [FieldAttr(265)] public bool _asynchronousHiZFlush;
        [FieldAttr(266)] public bool _flushAndSetSCull;
        [FieldAttr(268)] public EIG_GFX_STENCIL_FUNCTION _sCullFunction = EIG_GFX_STENCIL_FUNCTION.LESS;
        [FieldAttr(272)] public uint _sCullReference = 128;
        [FieldAttr(276)] public uint _sCullMask = 255;
        [FieldAttr(280)] public string? _sceneCameraName = "main";
        [FieldAttr(288)] public bool _enableReconstructionConstants;
        [FieldAttr(292)] public float _reconstructionCameraScale = 1.0f;
        [FieldAttr(296)] public igRenderCamera? _camera;
        [FieldAttr(304)] public igRenderCamera? _sceneCamera;
        [FieldAttr(312)] public igViewPositionReconstructionBundle? _viewPositionReconstructionParameters;
        [FieldAttr(320)] public igVectorMetaField<igSizeTypeMetaField> _rasterizerStates = new();
        [FieldAttr(344)] public igModelInstance.EViewportID _viewportID;
    }
}
