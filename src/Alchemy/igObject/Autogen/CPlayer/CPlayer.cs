namespace Alchemy
{
    [ObjectAttr(nst: 168, ctr: 248, align: 8)]
    public class CPlayer : igObject
    {
        [FieldAttr(nst: 16, ctr: 16)] public igHandleMetaField _hero = new();
        [FieldAttr(nst: 24)] public igHandleMetaField _vehicle = new();
        [FieldAttr(ctr: 24)] public igHandleMetaField _kart = new();
        [FieldAttr(nst: 32, ctr: 32)] public EController _controller = EController.ECONTROLLER_NONE;
        [FieldAttr(nst: 40, ctr: 40)] public u64 _controllerButtonStates;
        [FieldAttr(nst: 48, ctr: 48)] public u64 _controllerButtonClicks;
        [FieldAttr(nst: 56, ctr: 56)] public u64 _controllerButtonReleases;
        [FieldAttr(nst: 64, ctr: 64)] public CDisableRequestManager? _controllerVibration;
        [FieldAttr(nst: 72, ctr: 72)] public igVec2fMetaField _leftControllerAxis = new();
        [FieldAttr(nst: 80, ctr: 80)] public igVec2fMetaField _rightControllerAxis = new();
        [FieldAttr(nst: 88, ctr: 88)] public igVec3fMetaField _movement = new();
        [FieldAttr(nst: 104, ctr: 104)] public string? _gamertag = null;
        [FieldAttr(ctr: 112)] public int _mapVoteIndex;
        [FieldAttr(ctr: 116)] public int _wheelsIndex;
        [FieldAttr(ctr: 120)] public int _paintIndex;
        [FieldAttr(ctr: 124)] public int _decalIndex;
        [FieldAttr(ctr: 128)] public int _stickerIndex;
        [FieldAttr(nst: 112, ctr: 136)] public string? _characterName = null;
        [FieldAttr(nst: 120)] public string? _vehicleName = null;
        [FieldAttr(ctr: 144)] public igHandleMetaField _characterOutfit = new();
        [FieldAttr(ctr: 152)] public string? _kartName;
        [FieldAttr(nst: 128, ctr: 160)] public string? _displayGamertag = null;
        [FieldAttr(nst: 136, ctr: 168)] public u64 _onlineId;
        [FieldAttr(nst: 144, ctr: 176)] public EPlayerId _playerId = EPlayerId.EPLAYERID_NONE;
        [FieldAttr(nst: 148, ctr: 180)] public int _index;
        [FieldAttr(nst: 152, ctr: 184)] public int _previousHeroEntityIdIndex = -1;
        [FieldAttr(nst: 156, ctr: 188)] public bool _pendingJoin;
        [FieldAttr(nst: 157, ctr: 189)] public bool _joinedDuringMatchmaking;
        [FieldAttr(nst: 160, ctr: 192)] public float _skill;
        [FieldAttr(nst: 164, ctr: 196)] public bool _isSpectator;
        [FieldAttr(ctr: 200)] public int _netIndex;
        [FieldAttr(ctr: 208)] public string? _preloadCharacterName;
        [FieldAttr(ctr: 216)] public string? _preloadOutfitName;
        [FieldAttr(ctr: 224)] public bool _isPartyMember;
        [FieldAttr(ctr: 228)] public int _arenaTeamIndex;
        [FieldAttr(ctr: 232)] public bool _isDropped;
        [FieldAttr(ctr: 233)] public bool _isLobbyReady;
        [FieldAttr(ctr: 240)] public u64 _partyHostOnlineId;
    }
}
