namespace Alchemy
{
    [ObjectAttr(80, 16)]
    public class igFont : igNamedObject
    {
        public enum EHorizontalAlignment : uint
        {
            kHorizontalAlignmentLeft = 0,
            kHorizontalAlignmentRight = 1,
            kHorizontalAlignmentCenter = 2,
        }

        public enum EVerticalAlignment : uint
        {
            kVerticalAlignmentTop = 0,
            kVerticalAlignmentCenter = 1,
            kVerticalAlignmentBottom = 2,
        }

        [FieldAttr(24)] public float _height;
        [FieldAttr(28)] public float _blankLineSize = 1.0f;
        [FieldAttr(32)] public float _baseLine;
        [FieldAttr(40)] public igAttrList? _attrList;
        [FieldAttr(48)] public igVec4fMetaField _color = new();
        [FieldAttr(64)] public float _charPadding;
        [FieldAttr(68)] public bool _useNonbreakingUnderscore = true;
    }
}
