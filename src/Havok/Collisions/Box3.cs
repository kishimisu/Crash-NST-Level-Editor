using System.Numerics;

namespace Havok
{
    public class Box3
    {
        public Vector3 Min = Vector3.Zero;
        public Vector3 Max = Vector3.Zero;

        public Vector3 Center => (Min + Max) * 0.5f;

        public float SizeX => Max.X - Min.X;
        public float SizeY => Max.Y - Min.Y;
        public float SizeZ => Max.Z - Min.Z;
        
        public float Volume => SizeX * SizeY * SizeZ;
        public float SurfaceArea => 2.0f * (SizeX + SizeY + SizeZ);

        public Box3() {}
        public static Box3 Infinity => new(Vector3.PositiveInfinity, Vector3.NegativeInfinity);

        public Box3(Vector3 min, Vector3 max)
        {
            Min = min;
            Max = max;
        }

        public Box3(Box3 b)
        {
            Min = b.Min;
            Max = b.Max;
        }

        public Box3 SetFromPoints(IList<Vector3> points)
        {
            if (points.Count == 0) return this;

            Min = points[0];
            Max = points[0];

            for (int i = 1; i < points.Count; i++)
            {
                Encapsulate(points[i]);
            }

            return this;
        }

        public Box3 Encapsulate(Vector3 p)
        {
            Min = Vector3.Min(Min, p);
            Max = Vector3.Max(Max, p);

            return this;
        }

        public Box3 Encapsulate(Box3 b)
        {
            Min = Vector3.Min(Min, b.Min);
            Max = Vector3.Max(Max, b.Max);

            return this;
        }

        public float GetCenter(int axis)
        {
            return axis switch
            {
                0 => Center.X,
                1 => Center.Y,
                _ => Center.Z
            };
        }

        public float ComputeOverlap(Box3 b)
        {
            float x = MathF.Max(0, MathF.Min(Max.X, b.Max.X) - MathF.Max(Min.X, b.Min.X));
            float y = MathF.Max(0, MathF.Min(Max.Y, b.Max.Y) - MathF.Max(Min.Y, b.Min.Y));
            float z = MathF.Max(0, MathF.Min(Max.Z, b.Max.Z) - MathF.Max(Min.Z, b.Min.Z));

            return x * y * z;
        }

        public Box3 ApplyAffineMatrix(Matrix4x4 matrix)
        {
            var points = new Vector3[8];

            points[0] = ApplyAffineMatrix(Min.X, Min.Y, Min.Z, matrix); // 000
            points[1] = ApplyAffineMatrix(Min.X, Min.Y, Max.Z, matrix); // 001
            points[2] = ApplyAffineMatrix(Min.X, Max.Y, Min.Z, matrix); // 010
            points[3] = ApplyAffineMatrix(Min.X, Max.Y, Max.Z, matrix); // 011
            points[4] = ApplyAffineMatrix(Max.X, Min.Y, Min.Z, matrix); // 100
            points[5] = ApplyAffineMatrix(Max.X, Min.Y, Max.Z, matrix); // 101
            points[6] = ApplyAffineMatrix(Max.X, Max.Y, Min.Z, matrix); // 110
            points[7] = ApplyAffineMatrix(Max.X, Max.Y, Max.Z, matrix); // 111

            SetFromPoints(points);

            return this;
        }

        private static Vector3 ApplyAffineMatrix(float x, float y, float z, Matrix4x4 m)
        {
            return new Vector3(
                m.M11 * x + m.M12 * y + m.M13 * z + m.M14,
                m.M21 * x + m.M22 * y + m.M23 * z + m.M24,
                m.M31 * x + m.M32 * y + m.M33 * z + m.M34
            );
        }
    }
}