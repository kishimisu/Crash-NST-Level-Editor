namespace Alchemy
{
    [ObjectAttr(nst: 264, ctr: 296, align: 8)]
    public class CGuiBehaviorFriendListEntry : CGuiBehavior
    {
        [FieldAttr(nst: 144, ctr: 144, refCount: false)] public igGuiPlaceable? _gamertag;
        [FieldAttr(nst: 152, ctr: 152, refCount: false)] public igGuiPlaceable? _playerPicture;
        [FieldAttr(ctr: 160, refCount: false)] public igGuiPlaceable? _statusPlaceable;
        [FieldAttr(nst: 160, ctr: 168, refCount: false)] public igGuiAnimationTag? _gainFocusAnimation;
        [FieldAttr(nst: 168, ctr: 176, refCount: false)] public igGuiAnimationTag? _gainFocusIdleAnimation;
        [FieldAttr(nst: 176, ctr: 184, refCount: false)] public igGuiAnimationTag? _loseFocusAnimation;
        [FieldAttr(nst: 184, ctr: 192, refCount: false)] public igGuiAnimationTag? _loseFocusIdleAnimation;
        [FieldAttr(nst: 192, ctr: 200, refCount: false)] public igGuiAnimationTag? _onlineAnimation;
        [FieldAttr(nst: 200, ctr: 208, refCount: false)] public igGuiAnimationTag? _offlineAnimation;
        [FieldAttr(nst: 208, ctr: 216, refCount: false)] public igGuiAnimationTag? _joinableAnimation;
        [FieldAttr(nst: 216, ctr: 224, refCount: false)] public igGuiAnimationTag? _notJoinableAnimation;
        [FieldAttr(nst: 224, ctr: 232, refCount: false)] public igGuiAnimationTag? _inviteAnimation;
        [FieldAttr(nst: 232, ctr: 240, refCount: false)] public igGuiAnimationTag? _noInviteAnimation;
        [FieldAttr(nst: 240, ctr: 248)] public igHandleMetaField _friendInfo = new();
        [FieldAttr(nst: 248, ctr: 256)] public bool _isOnline;
        [FieldAttr(nst: 249, ctr: 257)] public bool _isJoinable;
        [FieldAttr(nst: 250, ctr: 258)] public bool _receivedInvite;
        [FieldAttr(nst: 256, ctr: 264)] public string? _presence = null;
        [FieldAttr(ctr: 272)] public string? _joinableString;
        [FieldAttr(ctr: 280)] public string? _notJoinableString;
        [FieldAttr(ctr: 288)] public string? _offlineString;
    }
}
