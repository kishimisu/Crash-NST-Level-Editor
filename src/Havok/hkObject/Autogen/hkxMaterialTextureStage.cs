using Alchemy;

namespace Havok
{
    [ObjectAttr(16)]
    public class hkxMaterialTextureStage : hkObject
    {
        public override uint Hash => 0xdbda7fbb;

        [FieldAttr(0)] public hkReferencedObject _texture; // TYPE_POINTER, ctype: hkReferencedObject, subtype: TYPE_STRUCT
        [FieldAttr(8)] public ETextureType _usageHint; // TYPE_ENUM, etype: TextureType, subtype: TYPE_INT32
        [FieldAttr(12)] public i32 _tcoordChannel; // TYPE_INT32
    }
}