namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CPhysicsSystemSkeletonBinding : igObject
    {
        [FieldAttr(16)] public igVectorMetaField<int> _boneToBodyArray = new();
        [FieldAttr(40)] public igVectorMetaField<i16> _boneToParentDynamicBlendIndexArray = new();
        [FieldAttr(64)] public bool _hasKeyframedBodies;
        [FieldAttr(65)] public bool _hasDynamicBodies;
    }
}
