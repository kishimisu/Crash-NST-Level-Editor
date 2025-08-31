namespace Alchemy
{
    [ObjectAttr(176, 16)]
    public class igGuiText : igGuiAsset
    {
        public enum ECapsMode : uint
        {
            kDefault = 0,
            kForceUpperCase = 1,
            kForceLowerCase = 2,
        }

        [FieldAttr(32)] public igHandleMetaField _font = new();
        [FieldAttr(40)] public ECapsMode _capsMode;
        [FieldAttr(48)] public igHandleMetaField _material = new();
        [FieldAttr(56)] public igHandleMetaField _shadowMaterial = new();
        [FieldAttr(64)] public igText.EColorMode _colorMode;
        [FieldAttr(68)] public igVec3fMetaField _modifierColorA = new();
        [FieldAttr(80)] public igVec3fMetaField _modifierColorB = new();
        [FieldAttr(92)] public igFont.EHorizontalAlignment _horizontalAlignment;
        [FieldAttr(96)] public igFont.EVerticalAlignment _verticalAlignment;
        [FieldAttr(100)] public float _fontScale = 1.0f;
        [FieldAttr(104)] public bool _forceFitInBox;
        [FieldAttr(105)] public bool _wordWrap;
        [FieldAttr(108)] public float _leading;
        [FieldAttr(112)] public float _tracking;
        [FieldAttr(116)] public bool _shadow;
        [FieldAttr(120)] public igVec2fMetaField _shadowOffset = new();
        [FieldAttr(128)] public igVec3fMetaField _shadowColor = new();
        [FieldAttr(140)] public float _shadowAlpha = 1.0f;
        [FieldAttr(144, false)] public igText? _renderText;
        [FieldAttr(152)] public igVec2fMetaField _finalFontScale = new();
        [FieldAttr(160)] public string? _previousDisplayText = null;
        [FieldAttr(168)] public string? _textInternal = null;
    }
}
