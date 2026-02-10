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

        /// <summary>
        /// Converts a ImGui color to THREE.Color
        /// </summary>
        public static THREE.Color FromImGuiColor(uint col)
        {
            THREE.Color color = new THREE.Color((int)col);
            color.SetRGB(color.B, color.G, color.R);
            return color;
        }

        /// <summary>
        /// Converts a THREE.Color to an ImGui color (uint)
        /// </summary>
        public static uint ToImGuiColor(this THREE.Color color, float soften = 0)
        {
            byte r = (byte)(color.R * (255 - soften) + soften);
            byte g = (byte)(color.G * (255 - soften) + soften);
            byte b = (byte)(color.B * (255 - soften) + soften);
            uint a = 255;
            return (a << 24) | ((uint)b << 16) | ((uint)g << 8) | r;
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

        // Alchemy -> System.Numerics
        public static System.Numerics.Vector3 ToNumericsVector3(this igVec3fMetaField v) => new System.Numerics.Vector3(v._x, v._y, v._z);
        public static System.Numerics.Vector4 ToNumericsVector4(this igVec4fMetaField v) => new System.Numerics.Vector4(v._x, v._y, v._z, v._w);

        // THREE -> Alchemy
        public static igVec3fMetaField ToVec3MetaField(this THREE.Vector3 v) => new igVec3fMetaField(v.X, v.Y, v.Z);
        public static igVec3fMetaField ToVec3MetaField(this THREE.Euler v) => new igVec3fMetaField(v.X, v.Y, v.Z);
        public static igVec3fMetaField Mul(this igVec3fMetaField v, float k) => new igVec3fMetaField(v._x * k, v._y * k, v._z * k);

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

        // System.Numerics -> Alchemy
        public static igVec3fMetaField ToVec3MetaField(this System.Numerics.Vector3 v) => new igVec3fMetaField(v.X, v.Y, v.Z);
        public static igVec4fMetaField ToVec4MetaField(this System.Numerics.Vector4 v) => new igVec4fMetaField(v.X, v.Y, v.Z, v.W);
    }
}