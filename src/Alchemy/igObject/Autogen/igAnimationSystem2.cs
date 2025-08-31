namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class igAnimationSystem2 : igNamedObject
    {
        [FieldAttr(24)] public igSkeleton2? _skeleton;
        [FieldAttr(32)] public igMemoryRef<igMatrix44fMetaField> _concatenatedBoneMatrixArray = new();
        [FieldAttr(48)] public igMemoryRef<igMatrix44fMetaField> _concatenatedBlendMatrixArray = new();
        [FieldAttr(64)] public int _matrixArrayTime = -2147483648;
    }
}
