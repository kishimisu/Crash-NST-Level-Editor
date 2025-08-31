namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igAnimationBinding2 : igObject
    {
        public enum EReflectionType : uint
        {
            kReflectNone = 0,
            kReflectPlaneYZ = 1,
            kReflectPlaneXZ = 2,
            kReflectPlaneXY = 3,
        }

        [FieldAttr(16)] public igSkeleton2? _skeleton;
        [FieldAttr(24)] public igMemoryRef<int> _boneTransformSourceIndexArray = new();
        [FieldAttr(40)] public int _bindCount;
        [FieldAttr(48)] public igIntList? _chainSwapList;
        [FieldAttr(56)] public igBitMask? _reflectionMask;
    }
}
