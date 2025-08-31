namespace Alchemy
{
    [ObjectAttr(200, 8)]
    public class CGuiBehaviorPauseMenuOption : CGuiBehavior
    {
        [FieldAttr(144)] public string? _build = "normal,final,beta";
        [FieldAttr(152)] public uint _gameMode = 4294967295;
        [FieldAttr(156)] public uint _nextGameMode = 4294967295;
        [FieldAttr(160)] public bool _visibleInHub = true;
        [FieldAttr(161)] public bool _visibleInIntro = true;
        [FieldAttr(162)] public bool _visibleForPrimaryPlayerOnly;
        [FieldAttr(163)] public bool _visibleOnPeer = true;
        [FieldAttr(168)] public igDeviceList? _restrictedDevices;
        [FieldAttr(176)] public CPauseMenuOption? _menuOption;
        [FieldAttr(184)] public bool _playTransitionAnimation;
        [FieldAttr(192)] public CGuiButtonLegendTable? _focusButtonLegendData;
    }
}
