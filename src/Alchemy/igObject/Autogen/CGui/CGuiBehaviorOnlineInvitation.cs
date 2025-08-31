namespace Alchemy
{
    [ObjectAttr(224, 8)]
    public class CGuiBehaviorOnlineInvitation : igGuiBehavior
    {
        public enum EOnlineInviteState : uint
        {
            eOIS_Closed = 0,
            eOIS_Opening = 1,
            eOIS_Open = 2,
            eOIS_Closing = 3,
        }

        public enum EOnlineInviteIcon : uint
        {
            eOII_None = 0,
            eOII_PlayerDisconnect = 1,
            eOII_ServerDisconnect = 2,
            eOII_ServerConnect = 3,
            eOII_Envelope = 4,
            eOII_Portrait = 5,
        }

        [FieldAttr(16, false)] public igGuiAnimationTag? _playerOneOpenAnimation;
        [FieldAttr(24, false)] public igGuiAnimationTag? _playerOneCloseAnimation;
        [FieldAttr(32, false)] public igGuiAnimationTag? _playerTwoOpenAnimation;
        [FieldAttr(40, false)] public igGuiAnimationTag? _playerTwoCloseAnimation;
        [FieldAttr(48, false)] public igGuiAnimationTag? _loopAnimation;
        [FieldAttr(56, false)] public igGuiPlaceable? _playerOneInfoPlaceable;
        [FieldAttr(64, false)] public igGuiPlaceable? _playerOneGamerPlaceable;
        [FieldAttr(72, false)] public igGuiPlaceable? _playerTwoInfoPlaceable;
        [FieldAttr(80, false)] public igGuiPlaceable? _playerTwoGamerPlaceable;
        [FieldAttr(88, false)] public igGuiPlaceable? _invitationIconPlaceable;
        [FieldAttr(96, false)] public igGuiPlaceable? _playerDisconnectIconPlaceable;
        [FieldAttr(104, false)] public igGuiPlaceable? _serverDisconnectIconPlaceable;
        [FieldAttr(112, false)] public igGuiPlaceable? _serverConnectIconPlaceable;
        [FieldAttr(120, false)] public igGuiPlaceable? _exclamationIconPlaceable;
        [FieldAttr(128, false)] public igGuiPlaceable? _playerPortraitPlaceable;
        [FieldAttr(136)] public string? _joinGamerText = null;
        [FieldAttr(144)] public string? _waitGamerText = null;
        [FieldAttr(152)] public string? _joinNotDisturbText = null;
        [FieldAttr(160)] public string? _inviteGamerText = null;
        [FieldAttr(168)] public string? _hostLeaveGamerText = null;
        [FieldAttr(176)] public string? _peerLeaveGamerText = null;
        [FieldAttr(184)] public string? _leaveMessageText = null;
        [FieldAttr(192)] public float _timeout;
        [FieldAttr(196)] public float _buttonHoldAbortJoinTime;
        [FieldAttr(200)] public float _timeElapsed;
        [FieldAttr(204)] public float _buttonHoldTime;
        [FieldAttr(208)] public EOnlineInviteState _state;
        [FieldAttr(212)] public EOnlineInviteIcon _icon;
        [FieldAttr(216)] public bool _exclamationVisible;
    }
}
