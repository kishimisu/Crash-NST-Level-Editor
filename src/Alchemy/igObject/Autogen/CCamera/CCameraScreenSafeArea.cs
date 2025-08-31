namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CCameraScreenSafeArea : igObject
    {
        [FieldAttr(16, false)] public CCamera? _owner;
        [FieldAttr(24)] public igVec2fMetaField _min = new();
        [FieldAttr(32)] public igVec2fMetaField _max = new();
        [FieldAttr(40)] public CConstraintMetaField _azimuthAngleConstraint = new();
        [FieldAttr(48)] public CConstraintMetaField _zenithAngleConstraint = new();
    }
}
