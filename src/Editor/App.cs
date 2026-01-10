using Alchemy;
using ImGuiNET;
using System.Diagnostics;

namespace NST
{
    /// <summary>
    /// Main application logic.
    /// Handles archive renderers and level editors
    /// </summary>
    public static class App
    {
        private static List<IgArchiveRenderer> _archives = [];
        private static List<LevelExplorer> _editors = [];

        private static MainMenu _mainMenu = new MainMenu();

        private static bool _showDemo = false;

        public static void Initialize()
        {
            LocalStorage.Initialize();

            _mainMenu.Initialize();
        }

        /// <summary>
        /// Render the application
        /// </summary>
        public static void Render(double deltaTime)
        {
            // Create fullscreen dockspace
            ImGui.DockSpaceOverViewport();

            // Render main menu
            if (!_mainMenu.IsOpen && _archives.Count == 0 && _editors.Count == 0)
            {
                _mainMenu.IsOpen = true;
            }
            _mainMenu.Render();

            // Render archives
            foreach (IgArchiveRenderer archive in _archives.ToList())
            {
                archive.Render();
            }

            // Render level explorers
            foreach (LevelExplorer viewer in _editors.ToList())
            {
                viewer.Render(deltaTime);
            }

            // Render modals if any
            ModalRenderer.RenderModals();

            if (_showDemo) ImGui.ShowDemoWindow();
        }

        /// <summary>
        /// Render the main menu bar
        /// </summary>
        public static void RenderHomeMenuBar()
        {
            if (ImGui.BeginMenuBar())
            {
                RenderFileMenu();
                RenderHelpMenu();
                ImGui.EndMenuBar();
            }
        }

        private static void RenderFileMenu()
        {
            if (ImGui.BeginMenu("File"))
            {
                if (ImGui.MenuItem("New mod")) OnClickNew();
                if (ImGui.MenuItem("Open archive")) OnClickOpen();
                RenderOpenRecent(true);
                ImGui.Separator();
                if (ImGui.MenuItem("Set game path")) LocalStorage.SetNewGamePath();
                if (ImGui.MenuItem("ImGui Demo")) _showDemo = !_showDemo;
                if (ImGui.MenuItem("Exit")) Environment.Exit(0);
                ImGui.EndMenu();
            }
        }

        public static void RenderHelpMenu()
        {
            if (ImGui.BeginMenu("Help"))
            {
                if (ImGui.MenuItem("Open project page (Github)")) {
                    OpenURL("https://github.com/kishimisu/Crash-NST-Level-Editor");
                }
                if (ImGui.MenuItem("Report an issue (Discord)")) {
                    OpenURL("https://discord.gg/vsnVrPvVjc");
                }
                ImGui.EndMenu();
            }
        }

        /// <summary>
        /// Render the recent files submenu
        /// </summary>
        public static void RenderOpenRecent(bool fromMainMenu = false, bool fromLevelEditor = false)
        {
            if (ImGui.BeginMenu("Open recent"))
            {
                ImGui.SeparatorText(fromLevelEditor ? "Recent Levels" : "Recent Archives");
                List<string> recent = fromLevelEditor ? LocalStorage.RecentLevels : LocalStorage.RecentFiles;

                foreach (string path in recent.ToList())
                {
                    if (ImGui.MenuItem(Path.GetFileName(path)))
                    {
                        try
                        {
                            OpenArchive(path, fromLevelEditor);
                            if (fromMainMenu) _mainMenu.IsOpen = false;
                        }
                        catch (Exception e)
                        {
                            ModalRenderer.ShowMessageModal("Error", e.Message);
                        }
                    }
                    if (ImGui.IsItemHovered()) ImGui.SetTooltip(path);
                }
                ImGui.EndMenu();
            }
        }
        
        /// <summary>
        /// Open the main menu
        /// </summary>
        public static void OpenMainMenu()
        {
            _mainMenu.IsOpen = true;
            ImGui.SetWindowFocus("Main Menu");
        }

        /// <summary>
        /// Open an archive from its path
        /// </summary>
        /// <param name="path">Path to the archive</param>
        /// <param name="openLevelEditor">Whether to open the level editor or archive renderer</param>
        public static IgArchiveRenderer OpenArchive(string path, bool openLevelEditor = false)
        {
            IgArchiveRenderer? renderer = _archives.Find(a => a.Archive.GetPath() == path);

            if (renderer != null)
            {
                // Archive is already opened, bring it to the front
                ImGui.SetWindowFocus(renderer.GetWindowName());
            }
            else
            {
                renderer = new IgArchiveRenderer(path);

                if (openLevelEditor)
                {
                    if (!renderer.IsLevelArchive)
                    {
                        throw new Exception("This archive is not a level archive.");
                    }
                    renderer.IsOpen = false;
                    OpenLevelExplorer(renderer);
                }
                else OpenArchiveRenderer(renderer);
            }

            LocalStorage.AddRecentFile(path, openLevelEditor && renderer.IsLevelArchive);

            return renderer;
        }

        /// <summary>
        /// Set focus on an existing archive renderer
        /// </summary>
        public static void OpenArchiveRenderer(IgArchiveRenderer archiveRenderer)
        {
            if (!_archives.Contains(archiveRenderer))
            {
                _archives.Add(archiveRenderer);
            }

            archiveRenderer.IsOpen = true;

            ImGui.SetWindowFocus(archiveRenderer.GetWindowName());
            LocalStorage.AddRecentFile(archiveRenderer.Archive.GetPath());
        }

        /// <summary>
        /// Set focus on a level editor, creating it if necessary
        /// </summary>
        public static void OpenLevelExplorer(IgArchiveRenderer archiveRenderer, igObject? objToFocus = null)
        {
            foreach (LevelExplorer editor in _editors)
            {
                if (editor.ArchiveRenderer == archiveRenderer)
                {
                    editor.IsOpen = true;
                    if (objToFocus != null) editor.Focus(objToFocus);
                    ImGui.SetWindowFocus(editor.GetWindowName());
                    return;
                }
            }

            LevelExplorer newEditor = new LevelExplorer(archiveRenderer, objToFocus);
            LocalStorage.AddRecentFile(archiveRenderer.Archive.GetPath(), true);
            _editors.Add(newEditor);
        }

        public static void AddLevelExplorer(LevelExplorer explorer) { _editors.Add(explorer); _mainMenu.IsOpen = false; }
        public static LevelExplorer? GetLevelExplorer(IgArchiveRenderer archive) => _editors.Find(e => e.ArchiveRenderer == archive);
        public static void CloseArchive(IgArchiveRenderer archive) => _archives.Remove(archive);
        public static bool CanCloseArchive(IgArchiveRenderer archive)
        {
            return !archive.IsUpdated || _editors.Find(e => e.ArchiveRenderer == archive)?.IsOpen == true;
        }
        
        public static void CloseExplorer(LevelExplorer explorer)
        {
            SilkWindow.instance.controls.Remove(explorer);

            explorer.Dispose();

            _editors.Remove(explorer);

            if (_editors.Count == 0 || LocalStorage.Get("clear_memory", true))
            {
                ThreeSceneRenderer.DisposeRenderer();
                _editors.ForEach(e => e.RebuildState = ThreeSceneRenderer.RebuildStatus.NeedsRebuild);
            }

            if (explorer.ReOpen)
            {
                OpenLevelExplorer(explorer.ArchiveRenderer);
            }
        }

        /// <summary>
        /// Focus an existing file renderer
        /// </summary>
        public static void FocusRenderer(FileRenderer renderer)
        {
            if (renderer is IgzRenderer igzRenderer)
            {
                OpenArchiveRenderer(igzRenderer.ArchiveRenderer);
                igzRenderer.ArchiveRenderer.FocusFile(renderer.ArchiveFile);
            }
            else
            {
                Console.WriteLine($"Warning: Renderer was not found in any archive ! ({renderer.GetWindowName()})");
            }
        }

        /// <summary>
        /// Find an object in the game files and focus it.
        /// </summary>
        /// <param name="reference">The object reference</param>
        /// <param name="renderer">(Optional) The source renderer</param>
        public static void FocusObject(NamedReference reference, IgzRenderer? renderer = null)
        {
            IgArchiveRenderer? parentArchive = renderer?.ArchiveRenderer;

            // Try to find file in the parent archive if provided
            if (parentArchive?.FocusObject(reference, renderer) == true)
            {
                if (!parentArchive.IsOpen)
                {
                    OpenArchiveRenderer(parentArchive);
                }
                else
            {
                ImGui.SetWindowFocus(parentArchive.GetWindowName());
                }
                return;
            }

            // Try to find file in currently opened archives
            foreach (IgArchiveRenderer archive in _archives)
            {
                if (archive == parentArchive) continue;
                if (archive.FocusObject(reference, renderer))
                {
                    ImGui.SetWindowFocus(archive.GetWindowName());
                    return;
                }
            }

            // Otherwise locate the parent archive in the game files
            NamespaceInfos? infos = NamespaceUtils.GetInfos(reference);

            if (infos == null)
            {
                ModalRenderer.ShowMessageModal("Failed to open file", $"File not found for {reference}.");
                return;
            }
            if (LocalStorage.GamePath == null)
            {
                ModalRenderer.ShowMessageModal("Could not complete operation", "Game path is not set.");
                return;
            }

            try {
                string pakPath = Path.Join(LocalStorage.GamePath, "archives", infos.pak);

                IgArchiveRenderer archiveRenderer = OpenArchive(pakPath);
                ImGui.SetWindowFocus(archiveRenderer.GetWindowName());
                archiveRenderer.FocusObject(reference, renderer);
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: Failed to open file {reference}: {e.Message}.");
                ModalRenderer.ShowMessageModal("Failed to open file", $"An error occured while opening {reference}.");
            }
        }

        public static IgArchiveFile? FindFile(string name, out IgArchive? archive, FileSearchType searchType = FileSearchType.NameWithExtension)
        {
            HashSet<IgArchiveRenderer> renderers = [];

            foreach (var a in _archives) renderers.Add(a);
            foreach (var e in _editors)  renderers.Add(e.ArchiveRenderer);

            archive = null;

            foreach (IgArchiveRenderer r in renderers)
            {
                IgArchiveFile? file = r.Archive.FindFile(name, searchType);
                if (file != null)
                {
                    archive = r.Archive;
                    return file;
                }
            }

            try 
            {
                return AlchemyUtils.FindFileInArchives(Path.GetFileNameWithoutExtension(name), out archive);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static void OnClickOpen(bool fromLevelEditor = false)
        {
            List<string> files = FileExplorer.OpenFiles(LocalStorage.ArchivePath, FileExplorer.EXT_ARCHIVES, false);

            if (files.Count == 0) return;

            try
            {
                OpenArchive(files[0], fromLevelEditor);
            }
            catch (Exception e)
            {
                ModalRenderer.ShowMessageModal("Error", e.Message);
            }

            _mainMenu.IsOpen = false;
        }

        public static void OnClickNew()
        {
            IgArchive archive = new IgArchive("");
            _archives.Add(new IgArchiveRenderer(archive));
            _mainMenu.IsOpen = false;
        }

        private static void OpenURL(string url)
        {
            try {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to open {url}: {e.Message}");
            }
        }
    }
}