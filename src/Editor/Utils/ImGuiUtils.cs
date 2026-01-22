using ImGuiNET;
using System.Numerics;

namespace NST
{
    /// <summary>
    /// Utilities for ImGui
    /// </summary>
    public static class ImGuiUtils
    {
        public static uint id = 0;

        private static Dictionary<string, string> _comboSearches = [];

        public static uint Uuid()
        {
            if (id == uint.MaxValue) id = 9999;
            return id++;
        }

        /// <summary>
        /// Add vertical spacing
        /// </summary>
        public static void VerticalSpacing(float height)
        {
            ImGui.Dummy(new Vector2(0, height));
        }

        /// <summary>
        /// Render a right-aligned button
        /// </summary>
        public static bool RightAlignedButton(string text, bool enabled = true)
        {
            float buttonWidth = ImGui.CalcTextSize(text).X + ImGui.GetStyle().FramePadding.X * 2;
            ImGui.SetCursorPosX(ImGui.GetCursorPosX() + ImGui.GetContentRegionAvail().X - buttonWidth);
            if (!enabled) ImGui.BeginDisabled();
            bool clicked = ImGui.Button(text, new Vector2(buttonWidth, 0));
            if (!enabled) ImGui.EndDisabled();
            return clicked;
        }

        public static bool SmallButtonAlignRight(string text, string label = "")
        {
            ImGui.SameLine();
            float width = ImGui.CalcTextSize(text).X + ImGui.GetStyle().FramePadding.X * 2 + 2;
            ImGui.SetCursorPosX(ImGui.GetCursorPosX() + ImGui.GetContentRegionAvail().X - width);
            return ImGui.SmallButton(text + "##" + label);
        }

        public static void Prefix(string text, float width = 0)
        {
            ImGui.Text(text);
            ImGui.SameLine(width);
        }

        /// <summary>
        /// Render a right-aligned text
        /// </summary>
        public static void RightAlignedText(string text, float? regionWidth = null)
        {
            regionWidth ??= ImGui.GetContentRegionAvail().X;

            float textWidth = ImGui.CalcTextSize(text).X;
            float startX = ImGui.GetCursorPosX() + regionWidth.Value - textWidth;

            ImGui.SetCursorPosX(startX);
            ImGui.Text(text);
        }

        /// <summary>
        /// Render text centered horizontally and vertically inside the current window or child
        /// </summary>
        public static void CenteredText(string text)
        {
            Vector2 windowSize = ImGui.GetWindowSize();
            Vector2 textSize = ImGui.CalcTextSize(text);

            float textX = (windowSize.X - textSize.X) * 0.5f;
            float textY = (windowSize.Y - textSize.Y) * 0.5f;

            ImGui.SetCursorPos(new Vector2(textX, textY));
            ImGui.Text(text);
        }

        public static bool CenteredButton(string text, Vector2? buttonSize = null)
        {
            Vector2 windowSize = ImGui.GetContentRegionAvail();
            Vector2 textSize = buttonSize ?? ImGui.CalcTextSize(text);

            float textX = (windowSize.X - textSize.X) * 0.5f;
            ImGui.SetCursorPosX(ImGui.GetCursorPosX() + textX);
            
            return ImGui.Button(text, buttonSize ?? Vector2.Zero);
        }

        public static void ColoredSeparator(string text, uint col)
        {
            ImGui.PushStyleColor(ImGuiCol.Text, 0xff000000 | col);
            ImGui.PushStyleColor(ImGuiCol.Separator, 0x66000000 | col);
            ImGui.SeparatorText(text);
            ImGui.PopStyleColor(2);
        }

        /// <summary>
        /// Truncate text to fit in a given width, adding "..."
        /// </summary>
        public static string TruncateTextToFit(string text, float maxWidth)
        {
            float textWidth = ImGui.CalcTextSize(text).X;
            
            if (textWidth <= maxWidth)
                return text;

            while (text.Length > 0 && ImGui.CalcTextSize(text + "...").X > maxWidth)
            {
                text = text.Substring(0, text.Length - 1);
            }
            return text + "...";
        }

        /// <summary>
        /// Check if the current element is visible in a scrollable region
        /// </summary>
        public static bool IsNodeVisible()
        {
            // Get the current node position (relative to the window's scroll region)
            float nodePosY = ImGui.GetCursorPosY();

            // Get the scroll region
            float scrollTop = ImGui.GetScrollY();
            float scrollBottom = scrollTop + ImGui.GetWindowHeight();

            // Check if the node is within the visible range
            return nodePosY >= scrollTop && nodePosY <= scrollBottom;
        }

        public static void RenderComboWithSearch(string label, string preview, List<string> options, bool fullWidth, Action<int, string> callback, string? firstOption = null)
        {
            if (!_comboSearches.TryGetValue(label, out string? comboSearch))
            {
                comboSearch = "";
            }

            if (fullWidth)
            {
                ImGui.SetNextItemWidth(-1);
            }

            if (ImGui.BeginCombo(label, preview))
            {
                ImGui.SetNextItemWidth(-1);

                if (ImGui.InputTextWithHint(label, "Search...", ref comboSearch, 256))
                {
                    _comboSearches[label] = comboSearch;
                }

                string searchLower = comboSearch.ToLower();

                if (firstOption != null && ImGui.Selectable(firstOption))
                {
                    callback(-1, firstOption);
                }

                for (int i = 0; i < options.Count; i++)
                {
                    string name = options[i];

                    if (!name.ToLower().Contains(searchLower)) continue;

                    if (ImGui.Selectable(name))
                    {
                        _comboSearches.Remove(label);
                        callback(i, name);
                    }
                }

                ImGui.EndCombo();
            }
        }
    }
}