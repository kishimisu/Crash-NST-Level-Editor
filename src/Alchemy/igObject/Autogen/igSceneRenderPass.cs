namespace Alchemy
{
    [ObjectAttr(464, 16)]
    public class igSceneRenderPass : igBaseRenderPass
    {
        [FieldAttr(352, false)] public igMetaObject? _passStateType = (null);
        [FieldAttr(360)] public igCommandStreamEncoderPassState? _passState;
        [FieldAttr(368)] public igSortKeyCommandDelegateObject? _passDelegate;
        [FieldAttr(376)] public bool _frustCullState = true;
        [FieldAttr(384)] public igHandleMetaField _auxiliaryCullingParameters = new();
        [FieldAttr(392)] public igHandleMetaField _lodParameters = new();
        [FieldAttr(400)] public igStringRefList? _modelClasses;
        [FieldAttr(408)] public u64 _modelClassMask;
        [FieldAttr(416)] public uint _modelFlags = 1;
        [FieldAttr(420)] public bool _renderOpaque = true;
        [FieldAttr(421)] public bool _renderAlphaTest = true;
        [FieldAttr(422)] public bool _renderTransparent = true;
        [FieldAttr(423)] public bool _enableVelocity;
        [FieldAttr(424)] public uint _sorterMode = 584;
        [FieldAttr(428)] public bool _useZSort;
        [FieldAttr(429)] public bool _resetStencilRef;
        [FieldAttr(432)] public EigSetStencilRefOperation _stencilRefOperation;
        [FieldAttr(440)] public igHandleMetaField _enableData = new();
        [FieldAttr(448)] public bool _enabled = true;
        [FieldAttr(452)] public int _disableCount;
    }
}
