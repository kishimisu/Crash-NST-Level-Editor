namespace Alchemy
{
    [ObjectAttr(272, 8)]
    public class igSprite : igObject
    {
        [FieldAttr(16)] public igVec2fMetaField[] _positions = new igVec2fMetaField[4];
        [FieldAttr(48)] public igVec2fMetaField[] _transformedPositions = new igVec2fMetaField[4];
        [FieldAttr(80)] public igVec2fMetaField[] _uvs = new igVec2fMetaField[4];
        [FieldAttr(112)] public igVec4ucMetaField[] _colors = new igVec4ucMetaField[4];
        [FieldAttr(128)] public igVec2fMetaField _scale = new();
        [FieldAttr(136)] public float _rotation;
        [FieldAttr(140)] public float _depth;
        [FieldAttr(144, false)] public igSpriteManager? _manager;
        [FieldAttr(152)] public string? _modelClass = null;
        [FieldAttr(160, false)] public igSpriteDrawCallModifier? _modifier;
        [FieldAttr(168)] public igHandleMetaField _renderTarget = new();
        [FieldAttr(176)] public igHandleMetaField _image = new();
        [FieldAttr(184)] public bool _blendState;
        [FieldAttr(185)] public bool _hidden;
        [FieldAttr(186)] public bool _visible;
        [FieldAttr(192)] public igAttrList? _renderAttrs;
        [FieldAttr(200)] public igGroup? _renderNode;
        [FieldAttr(208)] public igRawRefMetaField _renderMatrix = new();
        [FieldAttr(216)] public igRawRefMetaField _userData = new();
        [FieldAttr(224)] public bool _positionsDirty = true;
        [FieldAttr(225)] public bool _visibilityDirty = true;
        [FieldAttr(226)] public bool _skipTransformation;
        [FieldAttr(232)] public igRawRefMetaField _extraUvs = new();
        [FieldAttr(240, false)] public igSpriteBucket? _previousBucket;
        [FieldAttr(248, false)] public igSprite? _nextInBucket;
        [FieldAttr(256)] public igHandleMetaField _material = new();
        [FieldAttr(264)] public uint _bucketHash;
    }
}
