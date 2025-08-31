namespace Alchemy
{
    [ObjectAttr(128, 8)]
    public class igSpriteBucket : igObject
    {
        [FieldAttr(16)] public float _depth;
        [FieldAttr(24)] public igHandleMetaField _renderTarget = new();
        [FieldAttr(32)] public igHandleMetaField _image = new();
        [FieldAttr(40, false)] public igSpriteDrawCallModifier? _modifier;
        [FieldAttr(48)] public bool _hasValidPassId;
        [FieldAttr(49)] public u8 _passId;
        [FieldAttr(50)] public bool _blendState;
        [FieldAttr(56)] public igRawRefMetaField _extraUvs = new();
        [FieldAttr(64)] public igScissorNode? _scissor;
        [FieldAttr(72)] public igHandleMetaField _material = new();
        [FieldAttr(80)] public igSizeTypeMetaField _texture = new();
        [FieldAttr(88)] public igSizeTypeMetaField _sampler = new();
        [FieldAttr(96)] public int _spriteCount;
        [FieldAttr(104, false)] public igSprite? _firstSprite;
        [FieldAttr(112, false)] public igRenderer? _renderer;
        [FieldAttr(120)] public uint _hash;
    }
}
