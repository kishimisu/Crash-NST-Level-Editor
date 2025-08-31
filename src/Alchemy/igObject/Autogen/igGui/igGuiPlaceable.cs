namespace Alchemy
{
    [ObjectAttr(272, 16)]
    public class igGuiPlaceable : igObject
    {
        public enum EUpdateWhenHiddenMode : uint
        {
            kUseParentValue = 0,
            kEnable = 1,
            kDisable = 2,
        }

        [ObjectAttr(4)]
        public class BitfieldStorage : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _automaticBound = true;
            [FieldAttr(1, size: 1)] public bool _scissorToBound;
            [FieldAttr(2, size: 2)] public igGuiPlaceable.EUpdateWhenHiddenMode _updateWhenHiddenMode;
            [FieldAttr(4, size: 1)] public bool _xExtentRelativeToParent;
            [FieldAttr(5, size: 1)] public bool _yExtentRelativeToParent;
            [FieldAttr(6, size: 1)] public bool _xExtentEqualsScreenWidth;
            [FieldAttr(7, size: 1)] public bool _yExtentEqualsScreenHeight;
            [FieldAttr(8, size: 1)] public bool _hidden;
            [FieldAttr(9, size: 1)] public bool _allowTouchInput;
            [FieldAttr(10, size: 1)] public bool _dirty = false;
            [FieldAttr(11, size: 1)] public bool _finalHidden;
            [FieldAttr(12, size: 1)] public bool _updateWhenHidden;
            [FieldAttr(13, size: 1)] public bool _finalScissorToBound;
            [FieldAttr(14, size: 1)] public bool _deactivated;
            [FieldAttr(15, size: 1)] public bool _focusable = false;
            [FieldAttr(16, size: 1)] public bool _respectParentFocusability;
        }

        [FieldAttr(16)] public BitfieldStorage _bitfieldStorage = new();
        [FieldAttr(24)] public igGuiInstanceMap? _instanceMap;
        [FieldAttr(32, false)] public igGuiPlaceable? _sourcePlaceable;
        [FieldAttr(40, false)] public igGuiProject? _project;
        [FieldAttr(48)] public string? _name = null;
        [FieldAttr(56)] public string? _displayText = null;
        [FieldAttr(64)] public igHandleMetaField _asset = new();
        [FieldAttr(72, false)] public igGuiPlaceable? _parent;
        [FieldAttr(80)] public igGuiPlaceableTable? _children;
        [FieldAttr(88, false)] public igGuiPlaceable? _sortPrevious;
        [FieldAttr(96, false)] public igGuiPlaceable? _sortNext;
        [FieldAttr(104)] public igVec3fMetaField _position = new();
        [FieldAttr(116)] public igVec3fMetaField _pivot = new();
        [FieldAttr(128)] public igVec3fMetaField _rotation = new();
        [FieldAttr(140)] public igVec3fMetaField _scale = new();
        [FieldAttr(152)] public igVec3fMetaField _extent = new();
        [FieldAttr(164)] public EigGuiDeviceAutoScaleMode _autoScaleMode;
        [FieldAttr(168)] public EigGuiAnchorTargetX _xAnchor = EigGuiAnchorTargetX.kXAnchorCenter;
        [FieldAttr(172)] public EigGuiAnchorTargetY _yAnchor = EigGuiAnchorTargetY.kYAnchorCenter;
        [FieldAttr(176)] public igVec2fMetaField _texCoordMin = new();
        [FieldAttr(184)] public igVec2fMetaField _texCoordMax = new();
        [FieldAttr(192)] public igVec4fMetaField _color = new();
        [FieldAttr(208)] public float _alpha = 1.0f;
        [FieldAttr(216)] public igGuiBehaviorList? _behaviors;
        [FieldAttr(224)] public igGuiAnimationTable? _animations;
        [FieldAttr(232)] public igGuiEventActionTable? _eventActionTable;
        [FieldAttr(240)] public igRawRefMetaField _state = new();
        [FieldAttr(248)] public igGuiEventTable? _onEventTable;
        [FieldAttr(256)] public igGuiDelegateTable? _delegateTable;
    }
}
