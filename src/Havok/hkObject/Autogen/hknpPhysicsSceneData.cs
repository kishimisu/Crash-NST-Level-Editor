using Alchemy;

namespace Havok
{
    [ObjectAttr(40)]
    public class hknpPhysicsSceneData : hkReferencedObject
    {
        public override uint Hash => 0x701ce72c;

        [FieldAttr(16)] public hkMemoryPtr<hknpPhysicsSystemData> _systemDatas; // TYPE_ARRAY, ctype: hknpPhysicsSystemData, subtype: TYPE_POINTER
        [FieldAttr(32)] public hknpRefWorldCinfo _worldCinfo; // TYPE_POINTER, ctype: hknpRefWorldCinfo, subtype: TYPE_STRUCT
    }
}