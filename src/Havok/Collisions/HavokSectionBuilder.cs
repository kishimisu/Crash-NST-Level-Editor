namespace Havok
{
    public static class HavokSectionBuilder
    {
        private const int MaxPrimitivesPerSection = 127; // Don't change this

        private const int CandidateSplitsPerAxis = 16;
        private const float OverlapWeight = 1.0f;
        private const float VolumeWeight = 0.25f;
        private const float SurfaceAreaWeight = 0.1f;

        private class SplitCandidate
        {
            public float Cost;
            public int Axis;
            public int Index;

            public SplitCandidate(float cost = float.PositiveInfinity, int axis = 0, int index = -1)
            {
                Cost = cost;
                Axis = axis;
                Index = index;
            }
        }

        /// <summary>
        /// Splits a list of quads into sections (maximum 127 primitives per section)
        /// Used while rebuilding collisions for hknpCompressedMeshShape objects
        /// </summary>
        public static List<HkxSection> BuildSections(List<HkxPrimitive> primitives)
        {
            var output = new List<HkxSection>();

            if (primitives.Count > 0)
            {
                Split(primitives, output);
            }

            return output;
        }

        private static void Split(List<HkxPrimitive> primitives, List<HkxSection> output)
        {
            if (primitives.Count <= MaxPrimitivesPerSection)
            {
                output.Add(new HkxSection(primitives));
                return;
            }

            SplitCandidate split = FindBestSplit(primitives);

            primitives.Sort((a, b) => a.Bounds.GetCenter(split.Axis).CompareTo(b.Bounds.GetCenter(split.Axis)));

            var left = primitives.Take(split.Index).ToList();
            var right = primitives.Skip(split.Index).ToList();

            Split(left, output);
            Split(right, output);
        }

        private static SplitCandidate FindBestSplit(List<HkxPrimitive> primitives)
        {
            int minLeft = Math.Max(1, primitives.Count - MaxPrimitivesPerSection);
            int maxLeft = Math.Min(primitives.Count - 1, MaxPrimitivesPerSection);

            if (minLeft > maxLeft)
            {
                minLeft = 1;
                maxLeft = primitives.Count - 1;
            }

            var best = new SplitCandidate();

            for (int axis = 0; axis < 3; axis++)
            {
                var sorted = primitives.OrderBy(x => x.Bounds.GetCenter(axis));

                int candidateCount = Math.Min(maxLeft - minLeft + 1, CandidateSplitsPerAxis);

                for (int i = 0; i <= candidateCount; i++)
                {
                    int index = minLeft;

                    if (maxLeft - minLeft + 1 <= candidateCount) // Not enough candidates (evaluate all)
                    {
                        index += i;
                    }
                    else if (i == candidateCount) // Special case: evaluate middle candidate
                    {
                        index += (maxLeft - minLeft) / 2;
                    }
                    else // Evaluate evenly spaced candidates
                    {
                        index += (int)Math.Round(i / (float)MathF.Max(1, candidateCount - 1) * (maxLeft - minLeft));
                    }
                    
                    var left = sorted.Take(index).ToList();
                    var right = sorted.Skip(index).ToList();

                    float cost = EvaluateSplit(left, right);

                    if (cost < best.Cost)
                    {
                        best = new SplitCandidate(cost, axis, index);
                    }
                }
            }

            return best;
        }

        private static float EvaluateSplit(List<HkxPrimitive> left, List<HkxPrimitive> right)
        {
            Box3 leftBounds = ComputeBounds(left);
            Box3 rightBounds = ComputeBounds(right);

            float overlap = leftBounds.ComputeOverlap(rightBounds);
            float volume = new Box3(leftBounds).Encapsulate(rightBounds).Volume;

            float overlapCost = volume > 0.0 ? overlap / volume : 0;

            float volumeCost = NormalizedDifference(leftBounds.Volume, rightBounds.Volume);
            float surfaceAreaCost = NormalizedDifference(leftBounds.SurfaceArea, rightBounds.SurfaceArea);

            return overlapCost * OverlapWeight
                 + volumeCost * VolumeWeight
                 + surfaceAreaCost * SurfaceAreaWeight;
        }

        private static float NormalizedDifference(float a, float b)
        {
            float d = MathF.Max(MathF.Abs(a), MathF.Abs(b));
            
            return MathF.Abs(a - b) / MathF.Max(d, 1e-30f);
        }

        private static Box3 ComputeBounds(List<HkxPrimitive> primitives)
        {
            var box = new Box3(primitives[0].Bounds);

            for (int i = 1; i < primitives.Count; i++)
            {
                box.Encapsulate(primitives[i].Bounds);
            }

            return box;
        }
    }
}