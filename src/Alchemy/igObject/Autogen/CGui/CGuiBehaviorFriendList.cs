namespace Alchemy
{
    [ObjectAttr(nst: 328, ctr: 336, align: 8)]
    public class CGuiBehaviorFriendList : CGuiBehavior
    {
        [FieldAttr(nst: 144, ctr: 144, refCount: false)] public igGuiPlaceable? _placeable;
        [FieldAttr(nst: 152, ctr: 152, refCount: false)] public igGuiPlaceable? _friendsListPlaceable;
        [FieldAttr(nst: 160, ctr: 160, refCount: false)] public igGuiPlaceable? _noFriendsPlaceable;
        [FieldAttr(nst: 168, ctr: 168, refCount: false)] public igGuiPlaceable? _arrowUpPlaceable;
        [FieldAttr(nst: 176, ctr: 176, refCount: false)] public igGuiPlaceable? _arrowDownPlaceable;
        [FieldAttr(nst: 184, ctr: 184, refCount: false)] public igGuiAnimationTag? _openAnimation;
        [FieldAttr(nst: 192, ctr: 192, refCount: false)] public igGuiAnimationTag? _closeAnimation;
        [FieldAttr(nst: 200, ctr: 200, refCount: false)] public igGuiAnimationTag? _noFriendsAnimation;
        [FieldAttr(nst: 208, ctr: 208, refCount: false)] public igGuiAnimationTag? _joinEnabledAnimation;
        [FieldAttr(nst: 216, ctr: 216, refCount: false)] public igGuiAnimationTag? _joinDisabledAnimation;
        [FieldAttr(nst: 224, ctr: 224, refCount: false)] public igGuiAnimationTag? _inviteEnabledAnimation;
        [FieldAttr(nst: 232, ctr: 232, refCount: false)] public igGuiAnimationTag? _inviteDisabledAnimation;
        [FieldAttr(nst: 240, ctr: 240, refCount: false)] public igGuiAnimationTag? _arrowUpEnabledAnimation;
        [FieldAttr(nst: 248, ctr: 248, refCount: false)] public igGuiAnimationTag? _arrowUpDisabledAnimation;
        [FieldAttr(nst: 256, ctr: 256, refCount: false)] public igGuiAnimationTag? _arrowUpPressAnimation;
        [FieldAttr(nst: 264, ctr: 264, refCount: false)] public igGuiAnimationTag? _arrowUpReleaseAnimation;
        [FieldAttr(nst: 272, ctr: 272, refCount: false)] public igGuiAnimationTag? _arrowDownEnabledAnimation;
        [FieldAttr(nst: 280, ctr: 280, refCount: false)] public igGuiAnimationTag? _arrowDownDisabledAnimation;
        [FieldAttr(nst: 288, ctr: 288, refCount: false)] public igGuiAnimationTag? _arrowDownPressAnimation;
        [FieldAttr(nst: 296, ctr: 296, refCount: false)] public igGuiAnimationTag? _arrowDownReleaseAnimation;
        [FieldAttr(nst: 304, ctr: 304)] public igTimer? _refreshTimer;
        [FieldAttr(nst: 312, ctr: 312)] public bool _inputReceived;
        [FieldAttr(nst: 313, ctr: 313)] public bool _arrowUpDisabled;
        [FieldAttr(nst: 314, ctr: 314)] public bool _arrowDownDisabled;
        [FieldAttr(nst: 315, ctr: 315)] public bool _noFriends;
        [FieldAttr(nst: 320, ctr: 320)] public igGuiAnimationCategory? _introCategory;
        [FieldAttr(ctr: 328)] public bool _gamercardButtonVisible;
    }
}
