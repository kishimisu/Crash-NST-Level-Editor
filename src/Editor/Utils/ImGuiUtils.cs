using ImGuiNET;
using System.Numerics;

namespace NST
{
    /// <summary>
    /// Utilities for ImGui
    /// </summary>
    public static class ImGuiUtils
    {
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
        public static bool RightAlignedButton(string text, Vector2? buttonSize = null, bool enabled = true)
        {
            float buttonWidth = ImGui.CalcTextSize(text).X + ImGui.GetStyle().FramePadding.X * 2;
            ImGui.SetCursorPosX(ImGui.GetCursorPosX() + ImGui.GetContentRegionAvail().X - (buttonSize?.X ?? buttonWidth));
            if (!enabled) ImGui.BeginDisabled();
            bool clicked = ImGui.Button(text, buttonSize ?? Vector2.Zero);
            if (!enabled) ImGui.EndDisabled();
            return clicked;
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
        /// <returns></returns>
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
    }
}