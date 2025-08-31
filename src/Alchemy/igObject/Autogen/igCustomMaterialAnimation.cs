namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igCustomMaterialAnimation : igObject
    {
        [FieldAttr(16)] public igTransformSource3? _transform;
        [FieldAttr(24)] public string? _fieldName = null;
        [FieldAttr(32)] public EigCustomMaterialAnimationTarget _animationTarget;
        [FieldAttr(36)] public int _unitID = -1;
        [FieldAttr(40, false)] public igCustomMaterial? _owner;
    }
}
