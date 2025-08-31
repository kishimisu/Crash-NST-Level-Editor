namespace Alchemy
{
    [ObjectAttr(144, 16)]
    public class igGuiNineSlice : igGuiSprite
    {
        [FieldAttr(64)] public float _leftSize;
        [FieldAttr(68)] public float _rightSize;
        [FieldAttr(72)] public float _topSize;
        [FieldAttr(76)] public float _bottomSize;
        [FieldAttr(80, false)] public igSprite? _topLeftSprite;
        [FieldAttr(88, false)] public igSprite? _topSprite;
        [FieldAttr(96, false)] public igSprite? _topRightSprite;
        [FieldAttr(104, false)] public igSprite? _leftSprite;
        [FieldAttr(112, false)] public igSprite? _rightSprite;
        [FieldAttr(120, false)] public igSprite? _bottomLeftSprite;
        [FieldAttr(128, false)] public igSprite? _bottomSprite;
        [FieldAttr(136, false)] public igSprite? _bottomRightSprite;
    }
}
