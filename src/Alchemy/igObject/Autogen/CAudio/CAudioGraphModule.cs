namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CAudioGraphModule : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _sound = new();
        [FieldAttr(24)] public float _startPercent;
        [FieldAttr(28)] public float _endPercent = 100.0f;
        [FieldAttr(32)] public float _rootPitchPercent = 50.0f;
        [FieldAttr(36)] public float _fadeInPercent;
        [FieldAttr(40)] public float _fadeOutPercent;
        [FieldAttr(44)] public float _fadeInControlPointHeight = 0.69999999f;
        [FieldAttr(48)] public float _fadeOutControlPointHeight = 0.69999999f;
        [FieldAttr(52)] public bool _changePitch = true;
        [FieldAttr(56)] public igHandleMetaField _overrideSound = new();
        [FieldAttr(64)] public igHandleMetaField _playingSound = new();
    }
}
