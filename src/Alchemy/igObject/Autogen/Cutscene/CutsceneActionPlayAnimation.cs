namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class CutsceneActionPlayAnimation : CCutsceneAction
    {
        [FieldAttr(24)] public string? _animationName = null;
        [FieldAttr(32)] public CCutsceneActor? _actor;
        [FieldAttr(40)] public igVec3fMetaField _position = new();
        [FieldAttr(52)] public igVec3fMetaField _rotation = new();
        [FieldAttr(64)] public igVec3fMetaField _scale = new();
        [FieldAttr(80)] public CCutsceneActor? _boltTo;
        [FieldAttr(88)] public string? _boltBoneName = null;
    }
}
