using Alchemy;
using ImGuiNET;
using Silk.NET.Windowing;
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

        public static void Render(double deltaTime)
        {
            // Render top bar
            RenderMenuBar();

            // Create fullscreen dockspace
            ImGui.DockSpaceOverViewport();

            // Render main menu
            if (_archives.Count == 0 && _editors.Count == 0 && !_mainMenu.IsOpen)
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
                if (!viewer.IsOpen)
                {
                    _editors.Remove(viewer);
                }
                else 
                {
                    viewer.Render(deltaTime);
                }
            }

            // Render modals if any
            ModalRenderer.RenderModals();

            if (_showDemo) ImGui.ShowDemoWindow();
        }

        private static void RenderMenuBar()
        {
            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGui.MenuItem("New...", "Ctrl+N")) OnClickNew();
                    if (ImGui.MenuItem("Open...", "Ctrl+O")) OnClickOpen();
                    ImGui.Separator();
                    if (ImGui.MenuItem("Main Menu"))
                    {
                        _mainMenu.IsOpen = true;
                        ImGui.SetWindowFocus("Main Menu");
                    }
                    if (ImGui.MenuItem("Set game path")) LocalStorage.SetNewGamePath();
                    if (ImGui.MenuItem("Demo Window")) _showDemo = !_showDemo;
                    // if (ImGui.MenuItem("Run Tests")) Tests.TestEditor();
                    if (ImGui.MenuItem("Exit")) Environment.Exit(0);
                    ImGui.EndMenu();
                }
                if (ImGui.BeginMenu("About..."))
                {
                    if (ImGui.MenuItem("Open project page")) {
                        OpenURL("https://github.com/kishimisu/Crash-NST-Level-Editor");
                    }
                    ImGui.EndMenu();
                }

                _mainMenu.ModManager.RenderLevelSelect(400.0f);
                
                ImGui.EndMainMenuBar();
            }
        }

        public static void FocusRenderer(FileRenderer renderer)
        {
            foreach (IgArchiveRenderer archive in _archives)
            {
                if (archive.FileManager.HasRenderer(renderer))
                {
                    ImGui.SetWindowFocus(archive.GetWindowName());
                    archive.FocusFile(renderer.ArchiveFile);
                    return;
                }
            }

            Console.WriteLine($"WARNING: Renderer was not found in any archive ! ({renderer.GetWindowName()})");
        }

        public static IgArchiveRenderer OpenArchive(string path)
        {
            IgArchiveRenderer? renderer = _archives.Find(a => a.Archive.GetPath() == path);

            LocalStorage.AddRecentFile(path);

            if (renderer != null)
            {
                // Archive is already opened, bring it to the front
                ImGui.SetWindowFocus(renderer.GetWindowName());
            }
            else
            {
                renderer = new IgArchiveRenderer(path);
                
                _archives.Add(renderer);
            }

            return renderer;
        }

        public static void CloseArchive(IgArchiveRenderer archive)
        {
            _archives.Remove(archive);

            LevelExplorer? explorer = _editors.Find(e => e.ArchiveRenderer == archive);

            if (explorer != null)
            {
                _editors.Remove(explorer);
            }
        }

        public static IgArchiveFile? FindFile(string name, FileSearchType searchType = FileSearchType.NameWithExtension)
        {
            foreach (IgArchiveRenderer archiveRenderer in _archives)
            {
                IgArchiveFile? file = archiveRenderer.Archive.FindFile(name, searchType);
                if (file != null) return file;
            }

            NamespaceInfos? infos = NamespaceUtils.GetInfos(name);

            if (infos == null)
            {
                Console.WriteLine($"WARNING: Failed to find namespace infos for {name}.");
                return null;
            }
            if (infos.pak == null)
            {
                Console.WriteLine($"WARNING: NamespaceInfos {name} has no archive set.");
                return null;
            }
            if (LocalStorage.GamePath == null)
            {
                ModalRenderer.ShowMessageModal("Could not complete operation", "Game path is not set.");
                return null;
            }

            string pakName = infos.pak;
            string pakPath = Path.Join(LocalStorage.GamePath, "archives", pakName);

            if (!File.Exists(pakPath))
            {
                Console.WriteLine($"WARNING: Failed to find archive {pakPath} for {name}.");
                return null;
            }

            IgArchive archive = new IgArchive(pakPath);

            return archive.FindFile(name, searchType);
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

        public static void OpenLevelExplorer(IgArchiveRenderer archiveRenderer)
        {
            foreach (LevelExplorer viewer in _editors)
            {
                if (viewer.ArchiveRenderer == archiveRenderer)
                {
                    viewer.IsOpen = true;
                    ImGui.SetWindowFocus(viewer.GetWindowName());
                    return;
                }
            }
            
            _editors.Add(new LevelExplorer(archiveRenderer));
        }

        public static void FocusObject3D(IgArchive archive, igObject obj)
        {
            foreach (LevelExplorer explorer in _editors)
            {
                if (explorer.Archive.GetPath() == archive.GetPath())
                {
                    explorer.FocusObject(obj);
                    ImGui.SetWindowFocus(explorer.GetWindowName());
                    return;
                }
            }
        }

        public static void OnClickOpen()
        {
            List<string> files = FileExplorer.OpenFiles(LocalStorage.ArchivePath, FileExplorer.EXT_ALCHEMY, false);

            if (files.Count == 0) return;

            OpenArchive(files[0]);
        }

        public static void OnClickNew()
        {
            IgArchive archive = new IgArchive("");
            _archives.Add(new IgArchiveRenderer(archive));
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