namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igSkeleton2 : igNamedObject
    {
        [FieldAttr(24)] public igSkeletonBoneList? _boneList;
        [FieldAttr(32)] public igMemoryRef<igMatrix44fMetaField> _inverseJointArray = new();
    }
}
