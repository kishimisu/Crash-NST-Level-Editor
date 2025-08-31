namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class CGuiBehaviorPlayerWidget : igGuiBehavior
    {
        [FieldAttr(16, false)] public igGuiPlaceable? _rankPlaceable;
        [FieldAttr(24, false)] public igGuiPlaceable? _rankText;
        [FieldAttr(32, false)] public igGuiPlaceable? _profilePicture;
        [FieldAttr(40, false)] public igGuiPlaceable? _profileCrop;
        [FieldAttr(48, false)] public igGuiPlaceable? _loadingIcon;
        [FieldAttr(56, false)] public igGuiAnimationTag? _loadingAnimation;
        [FieldAttr(64)] public igHandleMetaField _defaultMaterial = new();
        [FieldAttr(72)] public igImage2? _image;
        [FieldAttr(80)] public igGraphicsMaterial? _gamerMaterial;
        [FieldAttr(88)] public igHandleMetaField _friendInfo = new();
        [FieldAttr(96, false)] public igGuiPlaceable? _behaviorPlace;
        [FieldAttr(104, false)] public igNetTask? _getPictureTask;
    }
}
