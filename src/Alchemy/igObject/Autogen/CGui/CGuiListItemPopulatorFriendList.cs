namespace Alchemy
{
    [ObjectAttr(nst: 40, ctr: 32, align: 8)]
    public class CGuiListItemPopulatorFriendList : igGuiListItemPopulator
    {
        [FieldAttr(nst: 16, ctr: 12)] public EPlayerId _playerId = EPlayerId.EPLAYERID_NONE;
        [FieldAttr(nst: 24, ctr: 16, refCount: false)] public igGuiAnimationTag? _noFriendAnimation;
        [FieldAttr(nst: 32, ctr: 24, refCount: false)] public igGuiPlaceable? _noFriendText;
    }
}
