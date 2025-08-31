namespace Alchemy
{
    [ObjectAttr(128, 8)]
    public class ActorInputCommand : igObject
    {
        [FieldAttr(16)] public i64 _buttonStates;
        [FieldAttr(24)] public i64 _buttonClicks;
        [FieldAttr(32)] public i64 _buttonReleases;
        [FieldAttr(40)] public igIntList? _buttonFrames;
        [FieldAttr(48)] public igIntListList? _stickFrames;
        [FieldAttr(56)] public float _speed;
        [FieldAttr(60)] public igVec3fMetaField _direction = new();
        [FieldAttr(72)] public igVec2fMetaField _initialTouchLocation = new();
        [FieldAttr(80)] public igVec2fMetaField _lastTouchLocation = new();
        [FieldAttr(88)] public igVec2fMetaField _lastMoveInput = new();
        [FieldAttr(96)] public igHandleMetaField _touchedEntity = new();
        [FieldAttr(104)] public igVec2fMetaField[] _analogStickDeflection = new igVec2fMetaField[3];
    }
}
