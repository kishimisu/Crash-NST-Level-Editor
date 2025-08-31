namespace Alchemy
{
    [ObjectAttr(368, 16)]
    public class igCommandStreamEncoderPassState : igObject
    {
        [FieldAttr(16)] public igMatrix44fMetaField _viewMatrix = new();
        [FieldAttr(80)] public igMatrix44fMetaField _previousViewMatrix = new();
        [FieldAttr(144)] public igMatrix44fMetaField _projMatrix = new();
        [FieldAttr(208)] public igMatrix44fMetaField _viewProjMatrix = new();
        [FieldAttr(272)] public uint _techniqueGlobalIndex;
        [FieldAttr(276)] public bool _useDefaultTechnique;
        [FieldAttr(277)] public u8 _flags;
        [FieldAttr(278)] public bool _useDistanceCull;
        [FieldAttr(280)] public int _viewportId;
        [FieldAttr(284)] public int _stencilRef = -1;
        [FieldAttr(288)] public EigSetStencilRefOperation _stencilRefOperation;
        [FieldAttr(296)] public igMemoryCommandStream? _overrideState;
        [FieldAttr(304)] public igHandleMetaField _overrideEffect = new();
        [FieldAttr(312)] public igTimeMetaField _time = new();
        [FieldAttr(320)] public igPickablePointLightDataList? _pointLights;
        [FieldAttr(328)] public igVec4fAtomicLinearAllocator? _pointLightAllocator;
        [FieldAttr(336)] public float _shaderLodDistance = -1.0f;
        [FieldAttr(340)] public float _shaderLodFadeScaleBias;
        [FieldAttr(344)] public igRawRefMetaField _projectiveShadowFrustum = new();
        [FieldAttr(352)] public bool _resetStencilRef;
        [FieldAttr(353)] public bool _enabled = true;
    }
}
