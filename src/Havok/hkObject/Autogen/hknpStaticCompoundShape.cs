using Alchemy;

namespace Havok
{
    [ObjectAttr(208)]
    public class hknpStaticCompoundShape : hknpCompoundShape
    {
        public override uint Hash => 0x4620d11c;

        [FieldAttr(192)] public hknpStaticCompoundShapeData _boundingVolumeData; // TYPE_POINTER, ctype: hknpStaticCompoundShapeData, subtype: TYPE_STRUCT
    }
}