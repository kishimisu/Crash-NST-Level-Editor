using ImGuiNET;
using System.Numerics;

namespace NST
{
    /// <summary>
    /// Renders the main menu shown when entering the application
    /// </summary>
    public class MainMenu
    {
        private ModManager _modManager = new ModManager();

        public bool IsOpen = true;

        /// <summary>
        /// Initializes the main menu
        /// </summary>
        public void Initialize()
        {
            // Load saved mods
            _modManager.Initialize();

            // Remove recent files that don't exist anymore
            foreach (string path in LocalStorage.RecentFiles.ToList())
            {
                if (!File.Exists(path)) LocalStorage.RemoveRecentFile(path);
            }
        }

        /// <summary>
        /// Renders the main menu
        /// </summary>
        public void Render()
        {
            if (!IsOpen) return;

            Vector2 displaySize = ImGui.GetIO().DisplaySize;
            Vector2 windowSize = displaySize * new Vector2(0.6f, 0.5f);
            Vector2 centerOffset = (displaySize - windowSize) * 0.5f;
            ImGui.SetNextWindowPos(displaySize * 0.5f, ImGuiCond.Appearing, new Vector2(0.5f, 0.5f));
            ImGui.SetNextWindowSize(windowSize, ImGuiCond.Appearing);

            if (ImGui.Begin("Main Menu", ref IsOpen))
            {
                ImGui.Columns(2);

                RenderHome();
                
                RenderRecentFiles();

                RenderGamePathNotSet();

                ImGui.NextColumn();

                _modManager.Render();
            }

            ImGui.End();
        }

        private void RenderGamePathNotSet()
        {
            if (LocalStorage.GamePath != null) return;

            ImGuiUtils.VerticalSpacing(25);

            float w = ImGui.GetContentRegionAvail().X * 0.5f;
            float x = ImGui.GetCursorPosX() + (ImGui.GetContentRegionAvail().X - w) * 0.5f;

            ImGui.SetCursorPosX(x);
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(.2f, 0.5f, 0.7f, 1.0f));
            if (ImGui.Button("Find game executable", new Vector2(w, 0))) LocalStorage.SetNewGamePath();
            ImGui.PopStyleColor();

            ImGuiUtils.VerticalSpacing(10);

            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4(1.0f, 0.6f, 0.3f, 1.0f));
            ImGui.Text("Warning: the game path isn't set. Some features may not work.");
            ImGui.PopStyleColor();
        }
        
        /// <summary>
        /// Renders the buttons to create or open a new archive
        /// </summary>
        private void RenderHome()
        {
            ImGui.SeparatorText("Create/edit mods");
            ImGuiUtils.VerticalSpacing(10);

            ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(15, 0));
            float buttonsWidth = ImGui.CalcTextSize("New Archive Open Archive").X + ImGui.GetStyle().FramePadding.X * 2;
            ImGui.SetCursorPosX(ImGui.GetCursorPosX() + (ImGui.GetContentRegionAvail().X - buttonsWidth) * 0.5f);

            if (ImGui.Button("New Mod")) App.OnClickNew();
            ImGui.SameLine();
            if (ImGui.Button("Open Archive")) App.OnClickOpen();
            
            ImGui.PopStyleVar();
        }

        /// <summary>
        /// Renders the list of recent files
        /// </summary>
        private void RenderRecentFiles()
        {
            if (LocalStorage.RecentFiles.Count == 0) return;

            ImGuiUtils.VerticalSpacing(10);
            ImGui.SeparatorText("Recent Files");

            foreach (string path in LocalStorage.RecentFiles.ToList())
            {
                string? dirPath = Path.GetDirectoryName(path);
                string? parentFolderName = Path.GetFileName(dirPath);
                string name = parentFolderName + "/" + Path.GetFileName(path);
                
                ImGui.SetNextItemAllowOverlap();
                ImGui.Selectable(name);

                bool isClicked = ImGui.IsItemClicked(ImGuiMouseButton.Left);
                bool isHovered = ImGui.IsItemHovered(ImGuiHoveredFlags.AllowWhenOverlapped);
                bool isHoveredDelay = ImGui.IsItemHovered(ImGuiHoveredFlags.DelayShort | ImGuiHoveredFlags.NoSharedDelay);

                ImGui.SameLine();

                float availWidth = ImGui.GetContentRegionAvail().X;
                float buttonWidth = ImGui.CalcTextSize("X").X + ImGui.GetStyle().FramePadding.X * 2;
                ImGui.SetCursorPosX(ImGui.GetCursorPosX() + availWidth - buttonWidth);

                ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(0.2f, 0.2f, 0.2f, 1.0f));
                if (ImGui.SmallButton("\u00d7##" + path))
                {
                    LocalStorage.RemoveRecentFile(path);
                }
                ImGui.PopStyleColor();

                if (ImGui.IsItemHovered(ImGuiHoveredFlags.AllowWhenOverlapped))
                {
                    ImGui.SetTooltip("Remove");
                }
                else if (isHoveredDelay)
                {
                    ImGui.SetTooltip(path);
                }

                if (isClicked)
                {
                    App.OpenArchive(path);
                    IsOpen = false;
                }
            }
        }
    }
}