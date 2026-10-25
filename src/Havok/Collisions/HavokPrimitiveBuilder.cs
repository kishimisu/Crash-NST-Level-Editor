using System.Numerics;

namespace Havok
{
    public static class HavokPrimitiveBuilder
    {
        private record Triangle(int A, int B, int C);
        private record Edge(int Triangle, int Start, int End);
        private record Quad(int TriangleA, int TriangleB, int A, int B, int C, int D, float Cost);

        public static List<HkxPrimitive> Build(List<Vector3> vertices, List<int> indices, int material = 0)
        {
            // Build triangles

            int triangleCount = indices.Count / 3;

            var triangles = new Triangle[triangleCount];

            for (int i = 0; i < triangleCount; i++)
            {
                int offset = i * 3;

                int a = indices[offset];
                int b = indices[offset + 1];
                int c = indices[offset + 2];

                triangles[i] = new Triangle(a, b, c);
            }

            // Build edges

            var edges = new Dictionary<ulong, List<Edge>>(triangleCount * 2);

            void AddEdge(int triangle, int start, int end)
            {
                ulong lo = (ulong)Math.Min(start, end);
                ulong hi = (ulong)Math.Max(start, end);
                ulong key = (lo << 32) | hi;

                if (!edges.TryGetValue(key, out var edgeTriangles))
                {
                    edgeTriangles = [];
                    edges[key] = edgeTriangles;
                }

                edgeTriangles.Add(new Edge(triangle, start, end));
            };

            for (int i = 0; i < triangleCount; i++)
            {
                var triangle = triangles[i];

                AddEdge(i, triangle.A, triangle.B);
                AddEdge(i, triangle.B, triangle.C);
                AddEdge(i, triangle.C, triangle.A);
            }

            // Build quad candidates

            var candidates = new List<Quad>();

            foreach (List<Edge> edgeTriangles in edges.Values)
            {
                for (int i = 0; i < edgeTriangles.Count; i++)
                {
                    var edge = edgeTriangles[i];

                    for (int j = i + 1; j < edgeTriangles.Count; j++)
                    {
                        var edgeB = edgeTriangles[j];
                        var triangleA = triangles[edge.Triangle];
                        var triangleB = triangles[edgeB.Triangle];

                        int a = edge.End;
                        int b = GetThirdVertex(triangleA, edge.Start, edge.End);
                        int c = edge.Start;
                        int d = GetThirdVertex(triangleB, edge.Start, edge.End);

                        float cost = EvaluateQuad(vertices[a], vertices[b], vertices[c], vertices[d]);

                        candidates.Add(new Quad(edge.Triangle, edgeB.Triangle, a, b, c, d, cost));
                    }
                }
            }

            candidates.Sort((a, b) => a.Cost.CompareTo(b.Cost));

            // Build quad primitives

            var output = new List<HkxPrimitive>();
            var used = new bool[triangleCount];

            foreach (Quad candidate in candidates)
            {
                if (used[candidate.TriangleA] || used[candidate.TriangleB])
                    continue;

                Vector3 a = vertices[candidate.A];
                Vector3 b = vertices[candidate.B];
                Vector3 c = vertices[candidate.C];
                Vector3 d = vertices[candidate.D];

                output.Add(new HkxPrimitive(a, b, c, d, material));

                used[candidate.TriangleA] = true;
                used[candidate.TriangleB] = true;
            }

            // Add single triangles

            for (int i = 0; i < triangleCount; i++)
            {
                if (used[i]) continue;

                var triangle = triangles[i];

                Vector3 a = vertices[triangle.A];
                Vector3 b = vertices[triangle.B];
                Vector3 c = vertices[triangle.C];

                output.Add(new HkxPrimitive(a, b, c, c, material));
            }

            return output;
        }

        private static float EvaluateQuad(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
        {
            const float epsilon = 1e-8f;

            Vector3 ab = b - a;
            Vector3 bc = c - b;
            Vector3 cd = d - c;
            Vector3 da = a - d;

            float lab = ab.Length();
            float lbc = bc.Length();
            float lcd = cd.Length();
            float lda = da.Length();

            if (lab < epsilon || lbc < epsilon || lcd < epsilon || lda < epsilon)
            {
                return float.PositiveInfinity; // Reject zero-length edges
            }

            Vector3 n1 = Vector3.Cross(b - a, c - a);
            Vector3 n2 = Vector3.Cross(c - a, d - a);

            float n1Length = n1.Length();
            float n2Length = n2.Length();

            if (n1Length < epsilon || n2Length < epsilon)
            {
                return float.PositiveInfinity;
            }

            n1 /= n1Length;
            n2 /= n2Length;

            // The two triangle normals should be similar
            float flatness = 1f - Math.Clamp(Vector3.Dot(n1, n2), -1f, 1f);

            // Pairs of adjacent edges should be perpendicular
            float angleCost =
                MathF.Abs(Vector3.Dot(ab / lab, -da / lda)) +
                MathF.Abs(Vector3.Dot(ab / lab, bc / lbc)) +
                MathF.Abs(Vector3.Dot(-bc / lbc, cd / lcd)) +
                MathF.Abs(Vector3.Dot(-cd / lcd, da / lda));

            angleCost *= 0.25f;

            // Opposite edges should be parallel
            Vector3 u = ab / lab;
            Vector3 v = cd / lcd;
            Vector3 x = bc / lbc;
            Vector3 y = da / lda;

            float parallelCost = (1f - MathF.Abs(Vector3.Dot(u, v)) + 1f - MathF.Abs(Vector3.Dot(x, y))) * 0.5f;

            // Opposites edges should have the same length
            float lengthCost = (MathF.Abs(lab - lcd) / MathF.Max(lab, lcd) + MathF.Abs(lbc - lda) / MathF.Max(lbc, lda)) * 0.5f;

            // Prioritize quads that are the most similar to flat squares
            return 0.15f * flatness
                 + 0.35f * angleCost
                 + 0.30f * parallelCost
                 + 0.20f * lengthCost;
        }

        private static int GetThirdVertex(Triangle t, int a, int b)
        {
            if (t.A != a && t.A != b) return t.A;
            if (t.B != a && t.B != b) return t.B;
            return t.C;
        }
    }
}