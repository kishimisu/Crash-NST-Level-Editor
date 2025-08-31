namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CPauseMenuOption : igLocalizedNamedObject
    {
        [FieldAttr(24)] public string? _description = null;
        [FieldAttr(32)] public igHandleMetaField _effect = new();
        [FieldAttr(40)] public igHandleMetaField _configureAnimation = new();
        [FieldAttr(48)] public igHandleMetaField _leftArrowPressedAnimation = new();
        [FieldAttr(56)] public igHandleMetaField _rightArrowPressedAnimation = new();
        [FieldAttr(64)] public igHandleMetaField _selectAnimation = new();
        [FieldAttr(72)] public igHandleMetaField _detailsImageMaterial = new();
        [FieldAttr(80)] public CGuiBehaviorPauseMenuOption? _behavior;
    }
}
