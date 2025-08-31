namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CMinigameData : igObject
    {
        [FieldAttr(16)] public string? _behaviorState = "Minigame";
        [FieldAttr(24)] public string? _endingBehaviorState = "Locomotion";
        [FieldAttr(32)] public string? _startBehaviorEvent = "Minigame_Start";
        [FieldAttr(40)] public string? _endBehaviorEvent = "Minigame_End";
        [FieldAttr(48)] public bool _lockControls = true;
        [FieldAttr(49)] public bool _hudEnabled = true;
        [FieldAttr(50)] public bool _playerVisible = true;
        [FieldAttr(51)] public bool _playerInvulnerable;
        [FieldAttr(52)] public bool _playerCollidable = true;
        [FieldAttr(53)] public bool _playerPhysicsEnabled = true;
        [FieldAttr(54)] public bool _playerAudible = true;
        [FieldAttr(55)] public bool _freezeCurrentSoundSettings;
    }
}
