using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(64)]
    public class hknpConvexShape : hknpShape
    {
        public override uint Hash => 0xc8f7c10d;

        [FieldAttr(48)] public hkList<Vector4> _vertices; // TYPE_RELARRAY, subtype: TYPE_VECTOR4
    }
}