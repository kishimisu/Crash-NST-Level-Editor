namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CGuiBehaviorPlayerHudLevelText : igGuiBehavior
    {
        [FieldAttr(16)] public EPlayerId _player = EPlayerId.EPLAYERID_NONE;
        [FieldAttr(24, false)] public igGuiPlaceable? _topLevel;
        [FieldAttr(32, false)] public igGuiPlaceable? _placeable;
    }
}
