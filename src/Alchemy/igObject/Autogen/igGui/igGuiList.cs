namespace Alchemy
{
    [ObjectAttr(848, 16)]
    public class igGuiList : igGuiControl
    {
        public enum EAlignmentMode : uint
        {
            kAlignmentLeftToRight = 0,
            kAlignmentRightToLeft = 1,
        }

        public enum ESortMode : uint
        {
            kSortByAlignment = 0,
            kSortByDistanceFromCenter = 1,
        }

        public enum EListFocusScrollMode : uint
        {
            kFocusScrollNone = 0,
            kFocusScrollToFit = 1,
            kFocusScrollCentered = 2,
        }

        public enum EListTouchScrollMode : uint
        {
            kTouchScrollNone = 0,
            kTouchScrollDragWithBounce = 1,
        }

        public enum EigTouchInputState : uint
        {
            kTouchStateIdle = 0,
            kTouchStatePressed = 1,
            kTouchStateDragging = 2,
        }

        [FieldAttr(32)] public igGuiPlaceable? _templateItem;
        [FieldAttr(40)] public igHandleMetaField _toolTemplateItem = new();
        [FieldAttr(48)] public igGuiListItemPopulator? _listItemPopulator;
        [FieldAttr(56)] public igGuiListItemConverter? _listItemConverter;
        [FieldAttr(64)] public igVec4fMetaField _margin = new();
        [FieldAttr(80)] public igVec4fMetaField _padding = new();
        [FieldAttr(96)] public float _itemShiftSpeed = 500.0f;
        [FieldAttr(100)] public float _scrollSpeed = 500.0f;
        [FieldAttr(104)] public bool _horizontalScroll;
        [FieldAttr(105)] public bool _listWrap = true;
        [FieldAttr(106)] public bool _acceptDpadInput = true;
        [FieldAttr(108)] public EAlignmentMode _alignmentMode;
        [FieldAttr(112)] public bool _centerAfterAlign;
        [FieldAttr(116)] public ESortMode _sortMode;
        [FieldAttr(120)] public EListFocusScrollMode _focusScrollMode = igGuiList.EListFocusScrollMode.kFocusScrollToFit;
        [FieldAttr(124)] public EListTouchScrollMode _touchScrollMode;
        [FieldAttr(128)] public bool _scissorListBounds = true;
        [FieldAttr(129)] public bool _alwaysCreatePlaceables = true;
        [FieldAttr(130)] public bool _unifyFocus;
        [FieldAttr(132)] public float _touchScrollingBuffer = 10.0f;
        [FieldAttr(136)] public float _touchScrollingDampening = 2.0f;
        [FieldAttr(140)] public float _touchScrollingDampeningRebound = 5.0f;
        [FieldAttr(144)] public EigGuiDeviceAutoScaleMode _itemAutoScaleMode;
        [FieldAttr(148)] public int _previewListItemCount = 10;
        [FieldAttr(152)] public float _scrollPercentage;
        [FieldAttr(156)] public float _visiblePercentage;
        [FieldAttr(160)] public float _lastScrollPercentage;
        [FieldAttr(164)] public float _touchScrollingVelocity;
        [FieldAttr(168)] public igVec2fMetaField _lastTouchPosition = new();
        [FieldAttr(176)] public EigTouchInputState _touchState;
        [FieldAttr(180)] public igGuiInput.EController _touchControl;
        [FieldAttr(184)] public igGuiInput.ESignal _touchSignal;
        [FieldAttr(192, false)] public igGuiPlaceable? _touchFocus;
        [FieldAttr(200)] public igGuiPlaceable? _rootPlaceable;
        [FieldAttr(208)] public igGuiPlaceable? _scrollPlaceable;
        [FieldAttr(216)] public igGuiListItemList? _items;
        [FieldAttr(224)] public igGuiListItemList? _sortedItems;
        [FieldAttr(232)] public igGuiListItemList? _visibleItems;
        [FieldAttr(240)] public igGuiListItemList? _cachedItems;
        [FieldAttr(248)] public igVec2fMetaField[] _cursor = new igVec2fMetaField[8];
        [FieldAttr(312)] public igObject[] _focusItem = new igObject[8];
        [FieldAttr(376)] public igObject[] _forcedFocusItem = new igObject[8];
        [FieldAttr(440)] public igHandleMetaField[] _hoverFocus = new igHandleMetaField[40];
        [FieldAttr(760)] public bool[] _hasFocus = new bool[8];
        [FieldAttr(768)] public bool[] _hasHover = new bool[40];
        [FieldAttr(808)] public float _scrollSize;
        [FieldAttr(812)] public bool _unboundedFocusScroll = true;
        [FieldAttr(813)] public bool _updateFocusScroll = true;
        [FieldAttr(814)] public bool _placeablesDirty = true;
        [FieldAttr(816)] public igGuiEventListVisibleUpdate? _visibleItemsEvent;
        [FieldAttr(824)] public igGuiEventPlaceableGainHover? _gainHoverEvent;
        [FieldAttr(832)] public igGuiEventPlaceableLoseHover? _loseHoverEvent;
    }
}
