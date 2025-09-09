using Alchemy;
using ImGuiNET;
using Silk.NET.Windowing;

namespace NST
{
    /// <summary>
    /// Main application logic.
    /// Handles archive renderers and level editors
    /// </summary>
    public static class App
    {
        private static List<IgArchiveRenderer> _archives = [];

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
            if (_archives.Count == 0 && !_mainMenu.IsOpen)
            {
                _mainMenu.IsOpen = true;
            }
            _mainMenu.Render();

            // Render archives
            foreach (IgArchiveRenderer archive in _archives.ToList())
            {
                archive.Render();
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
                    if (ImGui.MenuItem("Main Menu")) _mainMenu.IsOpen = true;
                    if (ImGui.MenuItem("Demo Window")) _showDemo = !_showDemo;
                    if (ImGui.MenuItem("Exit")) Environment.Exit(0);
                    ImGui.EndMenu();
                }
                if (ImGui.BeginMenu("Edit"))
                {
                    if (ImGui.MenuItem("Undo", "Ctrl+Z")) {}
                    if (ImGui.MenuItem("Redo", "Ctrl+Y")) {}
                    ImGui.EndMenu();
                }
                if (ImGui.BeginMenu("Help"))
                {
                    if (ImGui.MenuItem("About")) {}
                    ImGui.EndMenu();
                }
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

        public static void CloseArchive(IgArchiveRenderer archive) => _archives.Remove(archive);

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

            string pakName = infos.pak;
            string gamePath = LocalStorage.Get<string>("game_path", LocalStorage.DEFAULT_GAME_PATH);
            string pakPath = Path.Join(gamePath, "archives", pakName);

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

            if (renderer != null)
            {
                // Keep the parent renderer active to handle back navigation
                renderer.ArchiveRenderer.FileManager.KeepActive(renderer.ArchiveFile);
            }

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

            try {
                string pakName = infos.pak!;
                string gamePath = LocalStorage.Get<string>("game_path", LocalStorage.DEFAULT_GAME_PATH);
                string pakPath = Path.Join(gamePath, "archives", pakName);

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

        public static void OnClickOpen()
        {
            List<string> files = FileExplorer.OpenFiles(
                @"C:\Program Files (x86)\Steam\steamapps\common\Crash Bandicoot - N Sane Trilogy\archives",
                FileExplorer.EXT_ALCHEMY,
                false
            );

            if (files.Count == 0) return;

            OpenArchive(files[0]);
        }

        public static void OnClickNew()
        {
            IgArchive archive = new IgArchive("");
            _archives.Add(new IgArchiveRenderer(archive));
        }

        private static void OnClickImport()
        {
            List<string> files = FileExplorer.OpenFiles(
                @"C:\Program Files (x86)\Steam\steamapps\common\Crash Bandicoot - N Sane Trilogy\archives",
                FileExplorer.EXT_ALCHEMY,
                true
            );

            if (files.Count == 0) return;

            int archiveCount = files.Count(f => Path.GetExtension(f) == ".pak");

            if (archiveCount > 1)
            {
                ModalRenderer.ShowMessageModal("Invalid operation", "You can only import from one .pak archive at a time.");
                return;
            }

            if (archiveCount > 0 && archiveCount != files.Count)
            {
                ModalRenderer.ShowMessageModal("Invalid operation", "You can only import from one .pak archive at a time.");
                return;
            }
        }
    }
}