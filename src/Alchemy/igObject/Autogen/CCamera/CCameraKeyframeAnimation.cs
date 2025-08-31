namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CCameraKeyframeAnimation : igObject
    {
        [FieldAttr(16)] public igFloatList? _times;
        [FieldAttr(24)] public igVec3fList? _positions;
        [FieldAttr(32)] public igVec3fList? _rotations;
        [FieldAttr(40)] public igFloatList? _fovs;
    }
}
