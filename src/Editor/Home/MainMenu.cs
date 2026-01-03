using Alchemy;
using ImGuiNET;
using System.Numerics;

namespace NST
{
    /// <summary>
    /// Renders the main menu shown when entering the application
    /// </summary>
    public class MainMenu
    {
        public ModManager ModManager { get; } = new ModManager();

        public bool IsOpen = true;

        /// <summary>
        /// Initializes the main menu
        /// </summary>
        public void Initialize()
        {
            // Load saved mods
            ModManager.Initialize();

            // Remove recent files that don't exist anymore
            foreach (string path in LocalStorage.RecentFiles.Union(LocalStorage.RecentLevels).ToList())
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
            Vector2 windowSize = displaySize * new Vector2(0.6f, 0.45f);
            ImGui.SetNextWindowPos(displaySize * 0.5f, ImGuiCond.Appearing, new Vector2(0.5f, 0.5f));
            ImGui.SetNextWindowSize(windowSize, ImGuiCond.Appearing);

            if (ImGui.Begin("Main Menu", ref IsOpen, ImGuiWindowFlags.MenuBar))
            {
                // Menu bar
                App.RenderHomeMenuBar();

                ImGui.Columns(3);

                Vector2 firstSectionSize = new Vector2(0, 140);
                
                // Level editor

                ImGui.BeginChild("LevelMenu", firstSectionSize);
                LevelBuilder.Render();
                ImGui.EndChild();

                ImGui.SeparatorText("Recent Levels");

                ImGui.BeginChild("RecentLevels");
                RenderRecentFiles(true);
                ImGui.EndChild();

                // Archive editor

                ImGui.NextColumn();

                ImGui.BeginChild("ArchiveMenu", firstSectionSize);
                RenderArchiveMenu();
                ImGui.EndChild();
                
                ImGui.SeparatorText("Recent Archives");

                ImGui.BeginChild("RecentArchives");
                RenderRecentFiles(false);
                ImGui.EndChild();

                // Mod Manager

                ImGui.NextColumn();

                if (LocalStorage.GamePath != null)
                {
                    ModManager.Render();
                }
                else
                {
                    RenderGamePathNotSet();
                }
            }

            ImGui.End();
        }

        /// <summary>
        /// Renders the archive section from the main menu
        /// </summary>
        private static void RenderArchiveMenu()
        {
            Vector2 size = new Vector2(200, 0);

            ImGui.SeparatorText("Create/edit mods    ");

            ImGui.SameLine();
            ImGui.SetCursorPosX(ImGui.GetCursorPosX() - ImGui.CalcTextSize("    ").X);
            ImGui.TextDisabled("(?)");
            ImGui.SetItemTooltip("View and edit files inside .pak archives.\n\n- New Mod: Create a new empty .pak archive (mod)\n- Open Archive: View and edit a .pak archive (mod, level...)");

            ImGuiUtils.VerticalSpacing(10);

            if (ImGuiUtils.CenteredButton("New Mod...", size)) App.OnClickNew();
            ImGui.Spacing();
            if (ImGuiUtils.CenteredButton("Open Archive", size)) App.OnClickOpen();
        }

        /// <summary>
        /// Renders the list of recent files
        /// </summary>
        private void RenderRecentFiles(bool isLevel)
        {
            List<string> files = isLevel ? LocalStorage.RecentLevels : LocalStorage.RecentFiles;

            if (files.Count == 0)
            {
                ImGui.TextDisabled($"(No recent {(isLevel ? "level" : "archive")})");
                return;
            }

            ImGui.Indent();

            foreach (string path in files.ToList())
            {
                string? dirPath = Path.GetDirectoryName(path);
                string? parentFolderName = Path.GetFileName(dirPath);
                string name = parentFolderName + "/" + Path.GetFileName(path);
                
                ImGui.SetNextItemAllowOverlap();
                bool isClicked = ImGui.Selectable($"{name}##{isLevel}");
                bool isHoveredDelay = ImGui.IsItemHovered(ImGuiHoveredFlags.DelayShort | ImGuiHoveredFlags.NoSharedDelay);

                ImGui.SameLine();

                float availWidth = ImGui.GetContentRegionAvail().X;
                float removeWidth = ImGui.CalcTextSize("X").X + ImGui.GetStyle().FramePadding.X * 2;

                if (isLevel)
                {
                    float playWidth = ImGui.CalcTextSize("Play").X + ImGui.GetStyle().FramePadding.X * 2;
                    ImGui.SetCursorPosX(ImGui.GetCursorPosX() + availWidth - removeWidth - playWidth - ImGui.GetStyle().ItemSpacing.X);

                    bool isButtonActive = ModManager.CanClickPlay;
                    if (!isButtonActive) ImGui.BeginDisabled();
                    if (ImGui.SmallButton("Play##" + path)) IgArchive.Open(path).RunLevel();
                    if (!isButtonActive) ImGui.EndDisabled();
                    ImGui.SameLine();
                }
                else
                {
                    ImGui.SetCursorPosX(ImGui.GetCursorPosX() + availWidth - removeWidth);
                }

                ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(0.2f, 0.2f, 0.2f, 1.0f));
                if (ImGui.SmallButton("\u00d7##" + path + isLevel))
                {
                    LocalStorage.RemoveRecentFile(path, isLevel);
                }
                ImGui.PopStyleColor();

                if (ImGui.IsItemHovered())
                {
                    ImGui.SetTooltip("Remove");
                }
                else if (isHoveredDelay)
                {
                    ImGui.SetTooltip(path);
                }

                if (isClicked)
                {
                    try
                    {
                        App.OpenArchive(path, isLevel);
                        IsOpen = false;
                    }
                    catch (Exception e)
                    {
                        ModalRenderer.ShowMessageModal("Error", e.Message);
                    }
                }
            }

            ImGui.Unindent();
        }

        /// <summary>
        /// Renders a warning when the game folder isn't set as well as a button to open the file explorer
        /// </summary>
        private static void RenderGamePathNotSet()
        {
            float availX = ImGui.GetContentRegionAvail().X;
            float cursorX = ImGui.GetCursorPosX();

            const string text1 = "Warning: the game path isn't set!";
            const string text2 = "Some features may not work.";
            float textX1 = cursorX + (availX - ImGui.CalcTextSize(text1).X) * 0.5f;
            float textX2 = cursorX + (availX - ImGui.CalcTextSize(text2).X) * 0.5f;
            
            float buttonW = availX * 0.5f;
            float buttonX = cursorX + (availX - buttonW) * 0.5f;

            ImGuiUtils.VerticalSpacing(20);

            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4(1.0f, 0.6f, 0.3f, 1.0f));
            ImGui.SetCursorPosX(textX1); ImGui.Text(text1);
            ImGui.Spacing();
            ImGui.SetCursorPosX(textX2); ImGui.Text(text2);
            ImGui.PopStyleColor();

            ImGuiUtils.VerticalSpacing(15);

            ImGui.SetCursorPosX(buttonX);
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(.2f, 0.5f, 0.7f, 1.0f));
            if (ImGui.Button("Find game executable", new Vector2(buttonW, 0))) LocalStorage.SetNewGamePath();
            ImGui.PopStyleColor();
        }
    }
}