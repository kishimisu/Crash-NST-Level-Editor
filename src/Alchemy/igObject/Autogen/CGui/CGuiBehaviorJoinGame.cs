namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CGuiBehaviorJoinGame : igGuiBehavior
    {
        public enum EJoinGameBehaviorState : uint
        {
            eJGBS_Normal = 0,
            eJGBS_Closing = 1,
        }

        [FieldAttr(16, false)] public igGuiAnimationTag? _openAnimation;
        [FieldAttr(24, false)] public igGuiAnimationTag? _idleAnimation;
        [FieldAttr(32, false)] public igGuiAnimationTag? _closeAnimation;
        [FieldAttr(40, false)] public igGuiPlaceable? _buttonText;
        [FieldAttr(48)] public EPlayerId _player;
        [FieldAttr(52)] public EJoinGameBehaviorState _state;
        [FieldAttr(56)] public bool _activeOnLoad;
    }
}
