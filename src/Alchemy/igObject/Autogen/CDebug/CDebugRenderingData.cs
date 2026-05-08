namespace Alchemy
{
    [ObjectAttr(nst: 368, ctr: 384, align: 16)]
    public class CDebugRenderingData : igShaderConstantBundle
    {
        public enum EHighlightState
        {
            eHS_None = 0,
            eHS_IsWorld = 1,
            eHS_DistanceCullImportance = 2,
        }

        [FieldAttr(nst: 24, ctr: 24)] public float _normalMapScale = 1.0f;
        [FieldAttr(nst: 28, ctr: 28)] public bool _fixedDiffuseState;
        [FieldAttr(nst: 32, ctr: 32)] public igVec4fMetaField _fixedDiffuseColor = new();
        [FieldAttr(nst: 48, ctr: 48)] public bool _fixedMetalState;
        [FieldAttr(nst: 52, ctr: 52)] public float _fixedMetalValue;
        [FieldAttr(nst: 56, ctr: 56)] public bool _normalsOnlyState;
        [FieldAttr(nst: 57, ctr: 57)] public bool _lightingState = true;
        [FieldAttr(nst: 58, ctr: 58)] public bool _sunState = true;
        [FieldAttr(nst: 59, ctr: 59)] public bool _pointsState = true;
        [FieldAttr(nst: 60, ctr: 60)] public bool _boxesState = true;
        [FieldAttr(nst: 61, ctr: 61)] public bool _ambientState = true;
        [FieldAttr(nst: 62, ctr: 62)] public bool _ambientOcclusionState = true;
        [FieldAttr(nst: 63, ctr: 63)] public bool _diffuseState = true;
        [FieldAttr(nst: 64, ctr: 64)] public bool _specularState = true;
        [FieldAttr(nst: 65, ctr: 65)] public bool _shadowSplitState;
        [FieldAttr(nst: 66, ctr: 66)] public bool _drawLights;
        [FieldAttr(nst: 67, ctr: 67)] public bool _drawLightCulling;
        [FieldAttr(nst: 68, ctr: 68)] public bool _drawVisualDataBoxes;
        [FieldAttr(nst: 69, ctr: 69)] public bool _drawNoTiles = true;
        [FieldAttr(nst: 70, ctr: 70)] public bool _drawPointTiles;
        [FieldAttr(nst: 71, ctr: 71)] public bool _drawBoxTiles;
        [FieldAttr(nst: 72, ctr: 72)] public bool _drawHeroShadowDebugInfo;
        [FieldAttr(nst: 76, ctr: 76)] public float _cloudSortThreshold = 0.67460889f;
        [FieldAttr(nst: 80, ctr: 80)] public float _cloudFadeStart = 0.75f;
        [FieldAttr(nst: 84, ctr: 84)] public float _cloudFadeEnd = 1.0f;
        [FieldAttr(nst: 88, ctr: 88)] public bool _defocusState = true;
        [FieldAttr(nst: 89, ctr: 89)] public bool _overrideDefocusPlanes;
        [FieldAttr(nst: 96, ctr: 96)] public igVec4fMetaField _defocusPlanes = new();
        [FieldAttr(nst: 112, ctr: 112)] public bool _motionBlurState = true;
        [FieldAttr(nst: 113, ctr: 113)] public bool _bloomState = true;
        [FieldAttr(ctr: 114)] public bool _fxaaState;
        [FieldAttr(nst: 114, ctr: 115)] public bool _lutState = true;
        [FieldAttr(nst: 115, ctr: 116)] public bool _sunshaftState = true;
        [FieldAttr(nst: 116, ctr: 117)] public bool _defaultRenderer = true;
        [FieldAttr(nst: 117, ctr: 118)] public bool _mipMapRenderer;
        [FieldAttr(nst: 118, ctr: 119)] public bool _wireframeRenderer;
        [FieldAttr(nst: 119, ctr: 120)] public bool _noAesteticVis = true;
        [FieldAttr(nst: 120, ctr: 121)] public bool _chromaState;
        [FieldAttr(nst: 121, ctr: 122)] public bool _lumaState;
        [FieldAttr(nst: 122, ctr: 123)] public bool _edgesState;
        [FieldAttr(nst: 123, ctr: 124)] public bool _clippingState;
        [FieldAttr(nst: 124, ctr: 125)] public bool _noGbufferVis = true;
        [FieldAttr(nst: 125, ctr: 126)] public bool _gbufferNormalsVis;
        [FieldAttr(nst: 126, ctr: 127)] public bool _gbufferAlbedoVis;
        [FieldAttr(nst: 127, ctr: 128)] public bool _gbufferAlbedoClippingVis;
        [FieldAttr(nst: 128, ctr: 129)] public bool _gbufferGlossVis;
        [FieldAttr(nst: 129, ctr: 130)] public bool _gbufferMetalVis;
        [FieldAttr(nst: 130, ctr: 131)] public bool _gbufferEmissiveVis;
        [FieldAttr(nst: 131, ctr: 132)] public bool _gbufferBackscatterVis;
        [FieldAttr(nst: 132, ctr: 133)] public bool _noHighlightVis = true;
        [FieldAttr(nst: 133, ctr: 134)] public bool _highlightIsWorldState;
        [FieldAttr(nst: 134, ctr: 135)] public bool _highlightDistanceCullImportance;
        [FieldAttr(nst: 135, ctr: 136)] public bool _highlightCompressedState;
        [FieldAttr(nst: 136, ctr: 140)] public EHighlightState _highlightState;
        [FieldAttr(nst: 140, ctr: 144)] public bool _highlightModels;
        [FieldAttr(nst: 144, ctr: 152)] public CDebugHighlightColorBundle? _highlightIsWorldColor;
        [FieldAttr(nst: 152, ctr: 160)] public CDebugHighlightColorBundle? _highlightIsAutoWorldColor;
        [FieldAttr(nst: 160, ctr: 168)] public CDebugHighlightColorBundle? _highlightIsNotWorldColor;
        [FieldAttr(nst: 168, ctr: 176)] public CDebugHighlightColorBundle? _highlightVeryLowImportanceColor;
        [FieldAttr(nst: 176, ctr: 184)] public CDebugHighlightColorBundle? _highlightLowImportanceColor;
        [FieldAttr(nst: 184, ctr: 192)] public CDebugHighlightColorBundle? _highlightMediumImportanceColor;
        [FieldAttr(nst: 192, ctr: 200)] public CDebugHighlightColorBundle? _highlightHighImportanceColor;
        [FieldAttr(nst: 200, ctr: 208)] public CDebugHighlightColorBundle? _highlightCriticalImportanceColor;
        [FieldAttr(nst: 208, ctr: 216)] public EDeviceClass _platformEmulation = EDeviceClass.eDC_Gen8Console;
        [FieldAttr(nst: 212, ctr: 220)] public int _emulationIndex;
        [FieldAttr(nst: 216, ctr: 224)] public bool _parallaxState = true;
        [FieldAttr(nst: 217, ctr: 225)] public bool _parallaxSupersampleState = true;
        [FieldAttr(nst: 218, ctr: 226)] public bool _parallaxDepthState = true;
        [FieldAttr(nst: 219, ctr: 227)] public bool _parallaxHeightState;
        [FieldAttr(nst: 220, ctr: 228)] public bool _parallaxOpaqueUvsState;
        [FieldAttr(nst: 221, ctr: 229)] public bool _parallaxDecalUvsState;
        [FieldAttr(nst: 222, ctr: 230)] public bool _pixelCostRenderingEnabled;
        [FieldAttr(nst: 223, ctr: 231)] public bool _pixelCostAverageRecordingEnabled;
        [FieldAttr(nst: 224, ctr: 232)] public uint _pixelCostMode = 4294967295;
        [FieldAttr(nst: 228, ctr: 236)] public float _pixelCostAverageMax = 32.0f;
        [FieldAttr(nst: 240, ctr: 240)] public igVec4fMetaField _pixelCostColorThresholds = new();
        [FieldAttr(nst: 256, ctr: 256)] public bool _pauseGameOnPixelCostAverageMaxExceeded;
        [FieldAttr(nst: 257, ctr: 257)] public bool _vfxCoverageState;
        [FieldAttr(nst: 260, ctr: 260)] public EDebugVisibility _farSkyState = EDebugVisibility.kDebugVisibilityDefault;
        [FieldAttr(nst: 264, ctr: 264)] public EDebugVisibility _nearSkyState = EDebugVisibility.kDebugVisibilityDefault;
        [FieldAttr(nst: 268, ctr: 268)] public EDebugVisibility _staticEntityGeoState = EDebugVisibility.kDebugVisibilityDefault;
        [FieldAttr(nst: 272, ctr: 272)] public EDebugVisibility _dynamicEntityGeoState = EDebugVisibility.kDebugVisibilityDefault;
        [FieldAttr(nst: 276, ctr: 276)] public EDebugVisibility _actorGeoState = EDebugVisibility.kDebugVisibilityDefault;
        [FieldAttr(nst: 280, ctr: 280)] public EDebugVisibility _vehicleGeoState = EDebugVisibility.kDebugVisibilityDefault;
        [FieldAttr(nst: 284, ctr: 284)] public EDebugVisibility _cloudGeoState = EDebugVisibility.kDebugVisibilityDefault;
        [FieldAttr(nst: 288, ctr: 288)] public bool _buttonPromptState = true;
        [FieldAttr(nst: 289, ctr: 289)] public bool _vfxState = true;
        [FieldAttr(nst: 290, ctr: 290)] public bool _distanceCulling = true;
        [FieldAttr(nst: 291, ctr: 291)] public bool _flickerDistanceCulledObjects;
        [FieldAttr(nst: 292, ctr: 292)] public bool _occlusionTriggerCulling = true;
        [FieldAttr(nst: 293, ctr: 293)] public bool _drawOcclusionTriggers;
        [FieldAttr(nst: 294, ctr: 294)] public bool _listOcclusionTriggers;
        [FieldAttr(nst: 295, ctr: 295)] public bool _lightDistanceCulling = true;
        [FieldAttr(nst: 296, ctr: 296)] public bool _overrideClipPlanes;
        [FieldAttr(nst: 300, ctr: 300)] public float _nearClipPlane = 32.0f;
        [FieldAttr(nst: 304, ctr: 304)] public float _farClipPlane = 2.0f;
        [FieldAttr(nst: 308, ctr: 308)] public bool _overrideCullDistance;
        [FieldAttr(nst: 309, ctr: 309)] public bool _listCullDistances;
        [FieldAttr(nst: 312)] public int _fxaaPreset = 3;
        [FieldAttr(nst: 316, ctr: 312)] public float _cullDistanceVeryLow = 4000.0f;
        [FieldAttr(nst: 320, ctr: 316)] public float _cullDistanceLow = 8000.0f;
        [FieldAttr(nst: 324, ctr: 320)] public float _cullDistanceMedium = 16000.0f;
        [FieldAttr(nst: 328, ctr: 324)] public float _cullDistanceHigh = 24000.0f;
        [FieldAttr(nst: 332, ctr: 328)] public float _distanceCullFadeRange = 500.0f;
        [FieldAttr(nst: 336, ctr: 336)] public string? _shaderReloadTarget = null;
        [FieldAttr(nst: 344, ctr: 344)] public bool _debugState;
        [FieldAttr(nst: 352, ctr: 352)] public igHandleMetaField _currentRenderer = new();
        [FieldAttr(ctr: 360)] public float _hdrPaperWhiteNitsValue;
        [FieldAttr(ctr: 364)] public bool _hdrDoColorCorrectionCurve;
        [FieldAttr(ctr: 368)] public float _hdrHudNits;
        [FieldAttr(ctr: 372)] public float _hdrHudPow;
        [FieldAttr(ctr: 376)] public int _maxFurShells;
    }
}
