using ImGuiNET;

namespace NST
{
    /// <summary>
    /// Render and update a group of progress bars
    /// </summary>
    public class ProgressManager
    {
        /// <summary>
        /// Render a progress bar with a text
        /// </summary>
        private class ProgressEntry
        {
            public static readonly System.Numerics.Vector2 size = new System.Numerics.Vector2(400, 20);

            public float progress = 0;
            public string message = "";

            public static float StartX
            {
                get 
                {
                    float availWidth = ImGui.GetContentRegionAvail().X;
                    return ImGui.GetCursorPosX() + (availWidth - size.X) / 2;
                }
            }

            public void Render()
            {
                if (progress == 0) return;

                ImGui.SetCursorPosX(StartX);
                ImGui.ProgressBar(progress, size, message);
            }
        }

        /// <summary>
        /// Default entries (level editor)
        /// </summary>
        private Dictionary<string, ProgressEntry> _entries = new()
        {
            { "newlevel", new ProgressEntry() },
            { "entities", new ProgressEntry() },
            { "models", new ProgressEntry() },
            { "materials", new ProgressEntry() },
            { "textures", new ProgressEntry() }
        };

        public bool IsCompleted() => _entries.Values.All(e => e.progress == 1);

        /// <summary>
        /// Update a specific progress bar
        /// </summary>
        public void SetProgress(string key, float progress, string message)
        {
            _entries[key].progress = progress;
            _entries[key].message = message;
        }

        /// <summary>
        /// Render all active progress bars
        /// </summary>
        public void Render()
        {
            float availHeight = ImGui.GetContentRegionAvail().Y;
            ImGui.SetCursorPosY(ImGui.GetCursorPosY() + (availHeight - ProgressEntry.size.Y) / 2 - ProgressEntry.size.Y * 2.5f);

            foreach (ProgressEntry entry in _entries.Values)
            {
                entry.Render();
            }

            if (IsCompleted())
            {
                ImGui.SetCursorPosX(ProgressEntry.StartX);
                ImGuiUtils.RightAlignedText("Done. Creating scene...", ProgressEntry.size.X);
            }
        }
    }
}