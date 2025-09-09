using Alchemy;

namespace NST
{
    /// <summary>
    /// Maths and type conversion utilities
    /// </summary>
    public static class MathUtils
    {
        /// <summary>
        /// Converts a uint color to System.Numerics.Vector4
        /// </summary>
        public static System.Numerics.Vector4 UIntToVector4Numerics(uint color)
        {
            return new System.Numerics.Vector4(
                (color & 0xFF) / 255f, 
                ((color >> 8) & 0xFF) / 255f, 
                ((color >> 16) & 0xFF) / 255f, 
                ((color >> 24) & 0xFF) / 255f
            );
        }

        // Alchemy -> THREE
        public static THREE.Vector3 ToVector3(this igVec3fMetaField v) => new THREE.Vector3(v._x, v._y, v._z);
        public static THREE.Euler ToEuler(this igVec3fMetaField v) => new THREE.Euler(v._x, v._y, v._z, THREE.RotationOrder.ZYX);
        public static THREE.Quaternion ToQuaternion(this igVec3fMetaField v) => new THREE.Quaternion().SetFromEuler(v.ToEuler());
        public static THREE.Matrix4 ToMatrix4(this igMatrix44fMetaField m) => new THREE.Matrix4(
            m._row0._x, m._row0._y, m._row0._z, m._row0._w, 
            m._row1._x, m._row1._y, m._row1._z, m._row1._w, 
            m._row2._x, m._row2._y, m._row2._z, m._row2._w, 
            m._row3._x, m._row3._y, m._row3._z, m._row3._w
        );

        // THREE -> System.Numerics
        public static System.Numerics.Matrix4x4 ToMatrix4(this THREE.Matrix4 m) => new System.Numerics.Matrix4x4(
            m.Elements[0], m.Elements[1], m.Elements[2], m.Elements[3], 
            m.Elements[4], m.Elements[5], m.Elements[6], m.Elements[7], 
            m.Elements[8], m.Elements[9], m.Elements[10], m.Elements[11], 
            m.Elements[12], m.Elements[13], m.Elements[14], m.Elements[15]
        );

        // System.Numerics -> THREE
        public static THREE.Matrix4 ToMatrix4(this System.Numerics.Matrix4x4 m) => new THREE.Matrix4(
            m.M11, m.M21, m.M31, m.M41,
            m.M12, m.M22, m.M32, m.M42,
            m.M13, m.M23, m.M33, m.M43,
            m.M14, m.M24, m.M34, m.M44
        );
    }
}