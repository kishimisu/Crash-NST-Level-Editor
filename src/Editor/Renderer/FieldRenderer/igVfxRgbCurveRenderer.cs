using Alchemy;
using ImGuiNET;
using System.Numerics;

namespace NST
{
    public static class igVfxRgbCurveRenderer
    {
        private sealed class Key
        {
            public float Time;
            public System.Numerics.Vector3 Color;
            public System.Numerics.Vector3 RandomColor;
        }

        public static bool Render(igVfxRgbCurveMetaField c, string name)
        {
            var keys = ExtractKeys(c);
            bool updated = false;

            if (!ImGui.TreeNodeEx(name, ImGuiTreeNodeFlags.DefaultOpen)) 
                return false;

            ImGui.Spacing();

            ImGuiUtils.Prefix("Randomize");
            string[] names = ["R", "G", "B"];
            for (int ch = 0; ch < 3; ch++)
            {
                bool enabled = ((c._randomChannelMask >> ch) & 1) != 0;

                ImGui.SameLine();
                if (ImGui.Checkbox(names[ch], ref enabled))
                {
                    c._randomChannelMask = (byte)(enabled ? c._randomChannelMask | (1 << ch) : c._randomChannelMask & ~(1 << ch));
                    updated = true;
                }
            }

            int removeAt = -1;
            for (int i = 0; i < keys.Count; i++)
            {
                ImGui.PushID("##key" + i);

                float min = i == 0 ? 0f : keys[i-1].Time;
                float max = i == keys.Count - 1 ? 1f : keys[i+1].Time;
                float t = keys[i].Time;

                float spacing = ImGui.GetStyle().ItemSpacing.X;
                float avail = ImGui.GetContentRegionAvail().X - 60 - spacing * 3 - ImGui.CalcTextSize("X").X;

                ImGui.SetNextItemWidth(60);
                ImGui.BeginDisabled(i == 0 || i == keys.Count - 1);
                if (ImGui.DragFloat("##time", ref t, 0.001f, min, max, "%.3f"))
                {
                    keys[i].Time = Math.Clamp(t, min, max);
                    updated = true;
                }
                ImGui.EndDisabled();
                ImGui.SameLine();

                int pickers = c._randomChannelMask != 0 ? 2 : 1;
                float pickerWidth = Math.Max(60f, (avail - spacing * (pickers - 1)) / pickers);
            
                ImGui.SetNextItemWidth(pickerWidth);
                if (ImGui.ColorEdit3("##color", ref keys[i].Color))
                {
                    updated = true;
                }

                if (c._randomChannelMask != 0)
                {
                    ImGui.SameLine();
                    ImGui.SetNextItemWidth(pickerWidth);
                    if (ImGui.ColorEdit3("##randomColor", ref keys[i].RandomColor))
                    {
                        updated = true;
                    }
                }

                if (keys.Count > 1 && i > 0 && i < keys.Count)
                {
                    ImGui.SameLine();
                    if (ImGui.SmallButton("X")) removeAt = i;
                }

                ImGui.PopID();
            }

            if (removeAt >= 0)
            {
                keys.RemoveAt(removeAt);
                updated = true;
            }

            if (keys.Count < 5)
            {
                if (ImGui.Button("Add key"))
                {
                    if (keys.Count == 1)
                    {
                        keys.Add(new Key { Time = keys[0].Time, Color = keys[0].Color, RandomColor = keys[0].RandomColor });
                    }
                    else
                    {
                        int k = 0;
                        float best = -1f;
                        for (int i = 0; i < keys.Count - 1; i++)
                        {
                            float gap = keys[i+1].Time - keys[i].Time;
                            if (gap > best) { best = gap; k = i; }
                        }

                        var a = keys[k];
                        var b = keys[k+1];
                        keys.Insert(k + 1, new Key
                        {
                            Time = (a.Time + b.Time) * 0.5f,
                            Color = System.Numerics.Vector3.Lerp(a.Color, b.Color, 0.5f),
                            RandomColor = System.Numerics.Vector3.Lerp(a.RandomColor, b.RandomColor, 0.5f),
                        });
                    }

                    updated = true;
                }
            }

            var gradient = keys.Select(k => (k.Time, k.Color)).ToList();

            ImGui.TextDisabled("Preview");
            ImGuiUtils.RenderGradient(gradient);

            if (c._randomChannelMask != 0)
            {
                var gradientRandom = keys.Select(k => (k.Time, 
                    new System.Numerics.Vector3(
                        (c._randomChannelMask & 1) != 0 ? k.Color.X + (k.RandomColor.X - k.Color.X) : k.Color.X,
                        (c._randomChannelMask & 2) != 0 ? k.Color.Y + (k.RandomColor.Y - k.Color.Y) : k.Color.Y,
                        (c._randomChannelMask & 4) != 0 ? k.Color.Z + (k.RandomColor.Z - k.Color.Z) : k.Color.Z)
                    )).ToList();

                ImGui.TextDisabled("Preview (random)");
                ImGuiUtils.RenderGradient(gradientRandom);
            }

            if (updated)
            {
                RebuildCurve(c, keys);
            }

            ImGui.TreePop();

            return updated;
        }

        private static List<Key> ExtractKeys(igVfxRgbCurveMetaField c)
        {
            var endTimes = c._endTimes.ToArray();
            int keyCount = c._isConstant ? 1 : Math.Max(1, endTimes.Count(e => e >= 0) + 1);
            var keys = new List<Key>();

            var values = new List<igVec4fMetaField>(){ c._redValues, c._greenValues, c._blueValues }.Select(e => e.ToArray()).ToArray();
            var deltas = new List<igVec4fMetaField>(){ c._redDeltas, c._greenDeltas, c._blueDeltas }.Select(e => e.ToArray()).ToArray();
            var randomValues = new List<igVec4fMetaField>(){ c._redValuesRandom, c._greenValuesRandom, c._blueValuesRandom }.Select(e => e.ToArray()).ToArray();
            var randomDeltas = new List<igVec4fMetaField>(){ c._redDeltasRandom, c._greenDeltasRandom, c._blueDeltasRandom }.Select(e => e.ToArray()).ToArray();

            for (int k = 0; k < keyCount; k++)
            {
                var col = new float[3];
                var rnd = new float[3];

                for (int ch = 0; ch < 3; ch++)
                {
                    float value = k < 4 
                        ? values[ch][k] 
                        : values[ch][3] + deltas[ch][3];

                    float randomValue = k < 4
                        ? randomValues[ch][k] 
                        : randomValues[ch][3] + randomDeltas[ch][3];

                    col[ch] = value;

                    rnd[ch] = ((c._randomChannelMask >> ch) & 1) != 0
                        ? value + randomValue
                        : value;
                }

                keys.Add(new Key{
                    Time = k == 0 ? 0f : endTimes[k - 1],
                    Color = new System.Numerics.Vector3(col[0], col[1], col[2]),
                    RandomColor = new System.Numerics.Vector3(rnd[0], rnd[1], rnd[2])
                });
            }

            return keys;
        }

        private static void RebuildCurve(igVfxRgbCurveMetaField c, List<Key> keys)
        {
            bool constant = keys.Count == 1;

            if (constant)
            {
                keys.Add(new Key { Time = 1f, Color = keys[0].Color, RandomColor = keys[0].RandomColor });
            }

            keys[0].Time = 0f;
            keys[keys.Count-1].Time = 1f;

            int keyCount = keys.Count - 1;
            var endTimes = new float[4];
            var offsets = new float[4];
            var scales = new float[4];
            float prevEndTime = 0;

            for (int i = 0; i < 4; i++)
            {
                if (i < keyCount)
                {
                    float endTime = keys[i+1].Time;
                    float scale = 1f / (endTime - prevEndTime + 5e-7f);
                    float offset = -prevEndTime * scale;

                    prevEndTime = endTime;

                    endTimes[i] = endTime;
                    scales[i] = scale;
                    offsets[i] = offset;
                }
                else
                {
                    endTimes[i] = -1f;
                    offsets[i] = 0.5000001f;
                    scales[i] = -0.5000001f;
                }
            }
    
            List<igVec4fMetaField> values = [ c._redValues, c._greenValues, c._blueValues ];
            List<igVec4fMetaField> deltas = [ c._redDeltas, c._greenDeltas, c._blueDeltas ];
            List<igVec4fMetaField> randomValues = [ c._redValuesRandom, c._greenValuesRandom, c._blueValuesRandom ];
            List<igVec4fMetaField> randomDeltas = [ c._redDeltasRandom, c._greenDeltasRandom, c._blueDeltasRandom ];
            var b0 = new float[4];
            
            for (int ch = 0; ch < 3; ch++)
            {
                bool masked = ((c._randomChannelMask >> ch) & 1) != 0;
                var a = new float[5];
                var b = new float[5];
                for (int k = 0; k < 5; k++)
                {
                    if (k < keys.Count)
                    {
                        a[k] = keys[k].Color[ch];
                        b[k] = masked ? keys[k].RandomColor[ch] - a[k] : 0f;
                    }
                    else
                    {
                        a[k] = 1f;
                        b[k] = 0f;
                    }
                }
                b0[ch] = b[0];

                values[ch].Set(a[0], a[1], a[2], a[3]);
                deltas[ch].Set(a[1] - a[0], a[2] - a[1], a[3] - a[2], a[4] - a[3]);
                
                randomValues[ch].Set(b[0], b[1], b[2], b[3]);
                randomDeltas[ch].Set(b[1] - b[0], b[2] - b[1], b[3] - b[2], b[4] - b[3]);
            }

            c._isConstant = constant;

            c._endTimes = FromArray(endTimes);

            if (constant)
            {
                c._offsets = keys[0].Color.AsVector4().ToVec4MetaField();
                c._scales = FromArray(b0);
            }
            else
            {
                c._offsets = FromArray(offsets);
                c._scales = FromArray(scales);
            }
        }

        private static igVec4fMetaField FromArray(float[] v) => new igVec4fMetaField(v[0], v[1], v[2], v[3]);
        private static float[] ToArray(this igVec4fMetaField v) => [ v._x, v._y, v._z, v._w ];
        private static void Set(this igVec4fMetaField v, float x, float y, float z, float w)
        {
            v._x = x;
            v._y = y;
            v._z = z;
            v._w = w;
        }
    }
}