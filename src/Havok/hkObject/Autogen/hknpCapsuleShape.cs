using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(112)]
    public class hknpCapsuleShape : hknpConvexPolytopeShape
    {
        public override uint Hash => 0x60a75f4c;

        [FieldAttr(80)] public Vector4 _a; // TYPE_VECTOR4
        [FieldAttr(96)] public Vector4 _b; // TYPE_VECTOR4
    }
}