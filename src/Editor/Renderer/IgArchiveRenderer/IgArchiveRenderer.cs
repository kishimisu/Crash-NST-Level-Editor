using Alchemy;
using Havok;
using ImGuiNET;
using System.Numerics;

namespace NST
{
    /// <summary>
    /// Handles rendering of igArchive files
    /// </summary>
    public class IgArchiveRenderer
    {
        public IgArchive Archive { get; private set; }
        public ActiveFileManager FileManager { get; private set; }

        private IgArchiveTreeView _treeView;
        private IgArchiveFile? _selectedFile = null;
        private HashSet<IgArchiveFile> _includeInPackageFile = [];

        public bool IsOpen = true;
        public bool IsUpdated { get; set; } = false;
        public bool ForceSaveAs { get; set; } = false;
        public bool IsLevelArchive { get; private set; } = false;

        private uint _uuid;
        private bool _showAudioPlayer = false; // Used for .snd files
        private bool _hasBackup = false;
        private bool _rebuildPackageFile = true;
        private bool _hasPackageFile = false;

        public string GetWindowName() => (string.IsNullOrEmpty(Archive.GetName()) ? "New Archive" : Archive.GetName()) + "###" + _uuid;
        public bool IncludeInPackageFile(IgArchiveFile file) => !_hasPackageFile || _includeInPackageFile.Contains(file);

        public IgArchiveRenderer(string archivePath) : this(IgArchive.Open(archivePath)) { }

        public IgArchiveRenderer(IgArchive archive)
        {
            Archive = archive;
            _uuid = ImGuiUtils.Uuid();
            Setup();
        }

        private void Setup()
        {
            FileManager = new ActiveFileManager();

            _treeView = new IgArchiveTreeView(this);
            
            IgArchiveFile? packageFile = Archive.FindPackageFile();

            _hasBackup = File.Exists(Archive.GetPath() + ".backup");
            _hasPackageFile = (packageFile != null);
            _rebuildPackageFile = _hasPackageFile;
            _includeInPackageFile.Clear();
            _selectedFile = null;
            _showAudioPlayer = false;

            if (packageFile == null) return;

            IsLevelArchive = packageFile.GetPath().Substring("packages/generated/".Length).StartsWith("maps/");

            if (packageFile.GetName() == "chunkInfos_pkg.igz")
            {
                IsLevelArchive = false; // update.pak
            }
            
            IgzFile packageIgz = packageFile.ToIgzFile();
            igStreamingChunkInfo? chunkInfo = packageIgz.FindObject<igStreamingChunkInfo>();

            if (chunkInfo == null) return;

            List<string?> includedFiles = chunkInfo._required._data.Select(e => e._name).ToList();

            foreach (IgArchiveFile file in Archive.GetFiles())
            {
                if (file == packageFile) continue;

                string filePath = file.GetPath().ToLower();

                if (includedFiles.Remove(filePath))
                {
                    _includeInPackageFile.Add(file);
                }
            }
        }

        /// <summary>
        /// Adds a new file to the archive and updates the tree view
        /// </summary>
        public void AddFile(IgArchiveFile file, bool addToPackageFile = true, bool focusFile = false)
        {
            Archive.AddFile(file);
            _treeView.AddFile(file);
            
            SetFileUpdated(file, focusFile, isNewFile: true);

            if (addToPackageFile) _includeInPackageFile.Add(file);
        }

        /// <summary>
        /// Renders the window and its contents
        /// </summary>
        public void Render()
        {
            if (!IsOpen && TryCloseArchive())
            {
                return;
            }

            Vector2 displaySize = ImGui.GetIO().DisplaySize;
            ImGui.SetNextWindowSize(displaySize * new Vector2(1, 0.5f), ImGuiCond.FirstUseEver);
            ImGui.SetNextWindowPos(Vector2.Zero, ImGuiCond.FirstUseEver);

            ImGuiWindowFlags flags = ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse | ImGuiWindowFlags.MenuBar | ImGuiWindowFlags.NoSavedSettings;

            if (IsUpdated) flags |= ImGuiWindowFlags.UnsavedDocument;

            if (ImGui.Begin(GetWindowName(), ref IsOpen, flags))
            {
                float columnWidth = ImGui.GetContentRegionAvail().X * 0.3f;

                RenderMenuBar();
                
                if (IsLevelArchive && ImGui.Button("Open Level Editor"))
                {
                    App.OpenLevelExplorer(this);
                }

                if (ImGui.BeginTable("TreeAndInfo", 2, ImGuiTableFlags.Resizable | ImGuiTableFlags.RowBg))
                {
                    ImGui.TableSetupColumn("igArchiveTree", ImGuiTableColumnFlags.WidthFixed, columnWidth);
                    ImGui.TableSetupColumn("igzRenderer", ImGuiTableColumnFlags.WidthStretch);
                    ImGui.TableNextRow();
                    ImGui.TableNextColumn();

                    // Render tree view
                    _treeView.Render();

                    // Render current file
                    RenderFile();

                    ImGui.EndTable();
                }

                // Shortcuts
                if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.S)) TrySaveArchive(); // Save
                if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.ModShift | ImGuiKey.S)) SaveArchive(true); // Save as
                if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.L)) TrySaveArchive(true); // Save and run
                if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.E)) App.OpenLevelExplorer(this); // Level Explorer
                if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.ModShift | ImGuiKey.R)) RestoreBackup(false); // Restore backup
            }

            // Render undocked IGZs
            FileManager.RenderWindows();
            
            ImGui.End();
        }

        public void RenderMenuBar(bool fromLevelEditor = false)
        {
            if (ImGui.BeginMenuBar())
            {
                if (ImGui.MenuItem("\uE900"))
                {
                    App.OpenMainMenu();
                }
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGui.MenuItem("Open", "Ctrl+O")) App.OnClickOpen(fromLevelEditor);
                    App.RenderOpenRecent(fromLevelEditor: fromLevelEditor);
                    ImGui.Separator();
                    if (ImGui.MenuItem("Save", "Ctrl+S")) TrySaveArchive();
                    if (ImGui.MenuItem("Save as...", "Ctrl+Shift+S")) SaveArchive(true);
                    if (_hasPackageFile && ImGui.MenuItem("Save and run", "Ctrl+L")) TrySaveArchive(true);
                    if (ImGui.MenuItem("Compress and save")) TrySaveArchive(compress: true);

                    ImGui.Separator();

                    if (ImGui.BeginMenu("Archive"))
                    {
                        if (fromLevelEditor && ImGui.MenuItem("Open level archive"))
                        {
                            App.OpenArchiveRenderer(this);
                        }
                        ImGui.Separator();
                        AudioPlayerInstance.RenderAudioMenu();
                        if (ImGui.MenuItem("Rebuild package file", null, _rebuildPackageFile))
                        {
                            _rebuildPackageFile = !_rebuildPackageFile;
                            LocalStorage.Set("rebuild_package_file", _rebuildPackageFile);
                        }
                        ImGui.EndMenu();
                    }
                    if (ImGui.MenuItem("Close")) IsOpen = false;

                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Backup"))
                {
                    uint hash = NamespaceUtils.ComputeHash(Archive.GetPath());
                    string autoBackupPath = Path.Join(LocalStorage.GetStoragePath("backups"), $"{hash}.pak");
                    bool hasAutoBackup = File.Exists(autoBackupPath);


                    if (!_hasBackup && !hasAutoBackup)
                    {
                        ImGui.MenuItem("No backup found", null, false, false);
                        if (ImGui.MenuItem("Create backup")) CreateBackup();
                    }
                    else
                    {
                        ImGui.MenuItem("Backup found!", null, false, false);
                        if (hasAutoBackup)
                        {
                            FileInfo fileInfo = new FileInfo(autoBackupPath);
                            string formatted = fileInfo.LastWriteTime.ToString("dd/MM HH:mm");
                            if (ImGui.MenuItem($"Restore auto backup ({formatted})")) RestoreBackup(fromLevelEditor, autoBackupPath);
                        }
                        if (_hasBackup && ImGui.MenuItem("Restore backup", "Ctrl+Shift+R")) RestoreBackup(fromLevelEditor);
                        if (_hasBackup && ImGui.MenuItem("Delete backup")) DeleteBackup();
                    }
                    ImGui.EndMenu();
                }

                App.RenderHelpMenu();

                if (fromLevelEditor || IsLevelArchive)
                {
                    RenderPlayCurrentLevel();
                }

                ImGui.EndMenuBar();
            }
        }

        private void RenderPlayCurrentLevel()
        {
            string name = Archive.GetName();
            float w = ImGui.CalcTextSize("Play current level " + name).X + ImGui.GetStyle().FramePadding.X * 2;
            ImGui.SetCursorPosX(ImGui.GetCursorPosX() + ImGui.GetContentRegionAvail().X - w);

            ImGui.Text(name);
            ImGui.SameLine();

            bool isButtonActive = ModManager.CanClickPlay;

            if (!isButtonActive) ImGui.BeginDisabled();
            if (ImGui.Button("Play current level"))
            {
                if (ForceSaveAs)
                {
                    ModalRenderer.ShowMessageModal("Warning", "You need to save the level first");
                }
                else
                {
                    Archive.TryRunLevel();
                }
            }
            if (!isButtonActive) ImGui.EndDisabled();
        }

        private void CreateBackup()
        {
            File.Copy(Archive.GetPath(), Archive.GetPath() + ".backup");
            _hasBackup = true;
        }

        private void DeleteBackup()
        {
            ModalRenderer.ShowDeleteModal("Are you sure you want to delete the archive's backup?", () =>
            {
                File.Delete(Archive.GetPath() + ".backup");
                _hasBackup = false;
            });
        }

        private void RestoreBackup(bool fromLevelEditor, string? backupPath = null)
        {
            if (backupPath == null && !_hasBackup) return;

            // Restore backup
            backupPath ??= Archive.GetPath() + ".backup";
            File.Copy(backupPath, Archive.GetPath(), true);

            // Reset archive renderer
            Archive = IgArchive.Open(Archive.GetPath());
            Setup();

            // Reopen level explorer
            LevelExplorer? explorer = App.GetLevelExplorer(this);
            if (explorer != null)
            {
                explorer.IsOpen = false;
                explorer.ReOpen = fromLevelEditor;
            }

            if (!fromLevelEditor)
            {
                ModalRenderer.ShowMessageModal("Operation successful", "Backup has been restored.");
            }
        }

        /// <summary>
        /// Renders the currently selected file
        /// </summary>
        private void RenderFile()
        {
            if (_selectedFile == null) return;

            FileRenderer? renderer = FileManager.GetRenderer(_selectedFile);

            if (renderer != null)
            {
                ImGui.TableNextColumn();
                renderer.RenderContent();
                return;
            }

            string extension = Path.GetExtension(_selectedFile.GetName());

            ImGui.TableNextColumn();
            ImGui.Text(_selectedFile.GetName());
            ImGuiUtils.VerticalSpacing(10);

            // .snd files
            if (_showAudioPlayer)
            {
                AudioPlayerInstance.Render(newAudioData =>
                {
                    _selectedFile.SetData(newAudioData);
                    SetFileUpdated(_selectedFile, false);
                    AudioPlayerInstance.InitAudioPlayer(_selectedFile.GetData(), true, _selectedFile.GetName(false));
                });
            }
            // unsupported files
            else
            {
                string msg = $"    [ No preview available for {(extension == ".igz" ? "this file" : extension + " files")} ]";
                ImGui.TextColored(new Vector4(1, 0.7f, 0, 1), msg);
            }
        }

        /// <summary>
        /// Mark the archive and the file as updated
        /// </summary>
        /// <param name="file">The file that has been updated</param>
        /// <param name="focusFile">Whether to set the focus to the updated file.</param>
        /// <param name="isNewFile">Whether the updated file is a newly created file or an existing file</param>
        /// <param name="originalName">The original name of the file for rename operations</param>
        public FileUpdateInfos SetFileUpdated(IgArchiveFile file, bool focusFile = true, bool isNewFile = false, string? originalPath = null, bool fromLevelEditor = false)
        {
            FileUpdateInfos infos = FileManager.SetUpdated(file, isNewFile, originalPath, fromLevelEditor);
            
            if (focusFile)
            {
                IgArchiveTreeNode? node = _treeView.FindNode(file);
                if (node != null)
                {
                    FocusNode(node);
                }
            }

            IsUpdated = true;

            return infos;
        }

        /// <summary>
        /// Marks an object as updated. Also marks the archive and file as updated
        /// </summary>
        /// <param name="file">The parent file</param>
        /// <param name="obj">The object that has been updated</param>
        public FileUpdateInfos SetObjectUpdated(IgArchiveFile file, object? obj, bool fromLevelEditor = false)
        {
            FileUpdateInfos infos = SetFileUpdated(file, false, fromLevelEditor: fromLevelEditor);

            if (obj != null) {
                infos.updatedObjects.Add(obj);
            }
            
            return infos;
        }

        /// <summary>
        /// Marks an igEntity as updated with its collision data. Also marks the archive and file as updated
        /// </summary>
        /// <param name="entity">The entity that has been updated</param>
        /// <param name="shapeInstance">The corresponding shape instance if not in the same archive</param>
        public void SetEntityUpdated(NSTEntity entity, hknpShapeInstance? shapeInstance = null, bool removed = false)
        {
            FileUpdateInfos infos = SetObjectUpdated(entity.ArchiveFile, entity.Object);

            if (entity.CollisionShapeIndex == -1 && shapeInstance == null) return;

            if (infos.updatedCollisions.TryGetValue(entity, out CollisionUpdateInfos? collisionInfos))
            {
                collisionInfos.removed |= removed;
            }
            else
            {
                infos.updatedCollisions[entity] = new CollisionUpdateInfos()
                {
                    entity = entity,
                    removed = removed,
                    shapeInstance = shapeInstance,
                };
            }
        }

        /// <summary>
        /// Set the focus to a specific object in the archive
        /// </summary>
        /// <returns>True if the object was found</returns>
        public bool FocusObject(NamedReference reference, IgzRenderer? lastRenderer = null)
        {
            IgArchiveTreeNode? node = _treeView.FindNode(reference);

            if (node == null)
            {
                Console.WriteLine($"No file found for {reference} in {Archive.GetName()}");
                return false;
            }

            FocusNode(node, reference, lastRenderer, true);

            return true;
        }
        
        /// <summary>
        /// Focus a file in the tree view and open its content
        /// </summary>
        public void FocusFile(IgArchiveFile file, bool force = false)
        {
            FocusNode(_treeView.FindNode(file), force: force);
        }

        /// <summary>
        /// Focus a node in the tree view and open its corresponding file
        /// </summary>
        public void FocusNode(IgArchiveTreeNode? node, NamedReference? reference = null, IgzRenderer? lastRenderer = null, bool force = false)
        {
            if (_treeView.SelectedNode == node && !force)
            {
                return;
            }

            if (node == null)
            {
                _selectedFile = null;
                _treeView.SetSelectedNode(null);
                return;
            }

            _treeView.SetSelectedNode(node);

            if (node.File == null) return;

            node.NextFocus = NextFocusState.None;

            try 
            {
                OpenFile(node.File, reference, lastRenderer);
            }
            catch (Exception e)
            {
               ModalRenderer.ShowMessageModal("Warning", $"An error occured while opening {node.File.GetName()}:\n\n{e.Message}");
            }
        }
        
        /// <summary>
        /// Open a file in the archive.
        /// For .igz files, it will create a new IgzRenderer or focus an existing one
        /// For .snd files, it will create an Audio Player
        /// </summary>
        /// <param name="file">The file to open</param>
        /// <param name="reference">(Optional) Can be used to focus a specific object in the file after opening it</param>
        /// <param name="lastRenderer">(Optional) Can be used to create a back button to the previously opened IGZ file</param>
        private void OpenFile(IgArchiveFile file, NamedReference? reference = null, IgzRenderer? lastRenderer = null)
        {
            if (_selectedFile != null && _selectedFile != file)
            {
                FileManager.Remove(_selectedFile);
            }

            _selectedFile = file;
            _showAudioPlayer = false;

            if (!file.IsIGZ() && !file.IsHKX())
            {
                // Audio player for .snd files
                if (file.GetName().EndsWith(".snd"))
                {
                    _showAudioPlayer = true;
                    AudioPlayerInstance.InitAudioPlayer(file.Uncompress(), true, file.GetName(false));
                }

                return;
            }

            // Try to reuse an existing renderer
            FileUpdateInfos? infos = FileManager.GetInfos(file);
            FileRenderer? renderer = infos?.renderer;
            IgzRenderer? igzRenderer = renderer as IgzRenderer;

            if (renderer == null)
            {
                // Create a new renderer
                if (infos?.igz == null)
                {
                    renderer = FileRenderer.Create(file, this);
                    igzRenderer = renderer as IgzRenderer;
                    FileManager.Add(file, renderer);
                }
                // Create a new renderer using an open igz file
                else
                {
                    igzRenderer = new IgzRenderer(infos.igz, file, this);
                    renderer = infos.renderer = igzRenderer;
                }
            }
            // Focus the renderer
            else if (renderer.IsOpenAsWindow)
            {
                ImGui.SetWindowFocus(renderer.GetWindowName());
            }
            else if (igzRenderer?.TreeView.SelectedNode != null)
            {
                igzRenderer?.TreeView.SelectedNode.OnFocus(igzRenderer); // Re-focus to update audio player
            }

            if (reference != null && igzRenderer != null)
            {
                // Focus igz object node
                igzRenderer.TreeView.SelectNode(reference);

                // Setup back button
                if (igzRenderer != lastRenderer && lastRenderer != null) 
                {
                    if (!FileManager.HasRenderer(lastRenderer)) 
                    {
                        FileManager.Add(lastRenderer.ArchiveFile, lastRenderer);
                    }

                    FileManager.KeepActive(lastRenderer.ArchiveFile);
                    igzRenderer.LastRenderer = lastRenderer;
                }
            }
            else if (renderer.TreeView.SelectedNode != null)
            {
                renderer.TreeView.ExpandParents(renderer.TreeView.SelectedNode);
            }
        }

        private bool TryCloseArchive()
        {
            if (!App.CanCloseArchive(this))
            {
                ModalRenderer.ShowWarningModal($"Are you sure you want to close {Archive.GetName()} without saving?", () => { IsUpdated = false; IsOpen = false; });
                IsOpen = true;
                return false;
            }
            else
            {
                App.CloseArchive(this);
                return true;
            }
        }

        /// <summary>
        /// Try to save the current archive to disk.
        /// Will show a confirmation modal if it's a game archive.
        /// </summary>
        public void TrySaveArchive(bool launchGame = false, bool fromLevelEditor = false, bool compress = false)
        {
            if (!IsUpdated && !compress)
            {
                if (launchGame) Archive.TryRunLevel();
                return;
            }

            // Check if overwriting a game file
            if (!_hasBackup && Archive.FindCustomZoneInfoFile() == null && LocalStorage.GamePath != null && Archive.GetPath().StartsWith(LocalStorage.GamePath))
            {
                ModalRenderer.ShowConfirmationModal(
                    fromLevelEditor
                        ? "Warning: you're about to overwrite a game file!\n\nThe recommended approach is to create a copy of the original level\n(Save as...)."
                        : "Warning: you're about to overwrite a game file!\n\nThe recommended approach is to copy the files you want to edit to a new archive (mod), then use the mod manager to apply them.",
                    () =>  SaveArchive(true, launchGame, compress), // Save as...
                    () =>  SaveArchive(false, launchGame, compress) // Overwrite
                );
            }
            else
            {
                SaveArchive(false, launchGame, compress);
            }
        }

        /// <summary>
        /// Save the current archive to disk
        /// </summary>
        /// <param name="saveAs">If true will open the file saving explorer, otherwise will overwrite the current file</param>
        public void SaveArchive(bool saveAs = false, bool launchGame = false, bool compress = false)
        {
            string? path = Archive.GetPath();

            if (!string.IsNullOrEmpty(path) && LocalStorage.IsFileLocked(path))
            {
                ModalRenderer.ShowMessageModal("Could not save the archive", "This file is currently being used by the game.");
                return;
            }

            // Check that all object names are unique
            foreach ((IgArchiveFile archiveFile, FileUpdateInfos infos) in FileManager.GetUpdatedFiles())
            {
                if (infos.igz == null) continue;

                HashSet<string> objectNames = [];

                foreach (igObject obj in infos.igz.Objects)
                {
                    if (obj.ObjectName != null && !objectNames.Add(obj.ObjectName))
                    {
                        ModalRenderer.ShowMessageModal("Could not save the archive", $"Found duplicate object name: {obj.ObjectName}\nin {archiveFile.GetPath()}");
                        return;
                    }
                }
            }

            if (saveAs || ForceSaveAs || string.IsNullOrEmpty(path))
            {
                path = FileExplorer.SaveFile("", FileExplorer.EXT_ARCHIVES, Archive.GetName());
                if (path == null) return;
                LocalStorage.AddRecentFile(path, IsLevelArchive);
                ForceSaveAs = false;
            }

            ModalRenderer.ShowLoadingModal($"Saving{(compress ? " compressed " : " ")}archive...");

            Task.Run(() =>
            {
                List<CollisionUpdateInfos> updatedCollisions = [];

                // Loop through all updated files
                foreach ((IgArchiveFile archiveFile, FileUpdateInfos infos) in FileManager.GetUpdatedFiles())
                {
                    // Add updated collisions
                    updatedCollisions.AddRange(infos.updatedCollisions.Values);

                    // Save file
                    bool isFileEmpty = FileManager.ApplyChanges(infos, _selectedFile != archiveFile);

                    if (isFileEmpty) 
                    {
                        Console.WriteLine("Removing empty file: " + archiveFile.GetName());
                        RemoveFile(archiveFile);
                    }
                }

                // Rebuild collisions if needed
                if (updatedCollisions.Count > 0)
                {
                    StaticCollisionsUtils.RebuildCollisions(Archive, updatedCollisions);
                }

                if (IsLevelArchive && saveAs && Archive.FindCustomZoneInfoFile() == null)
                {
                    LevelBuilder.ConvertToCustomLevel(Archive);
                }

                // Rebuild package file if needed
                if (_rebuildPackageFile)
                {
                    List<IgArchiveFile> includedFiles = Archive.GetFiles().Where(e => _includeInPackageFile.Contains(e)).ToList();
                    Archive.RebuildPackageFile(includedFiles, out IgArchiveFile? newPackageFile);
                    if (newPackageFile != null) _treeView.AddFile(newPackageFile);
                }

                if (compress)
                {
                    Archive.CompressAll();
                }

                if (launchGame && File.Exists(Archive.GetPath()))
                {
                    try
                    {
                        // Create backup
                        uint hash = NamespaceUtils.ComputeHash(path);
                        string backupDir = LocalStorage.GetStoragePath("backups");
                        string backupPath = Path.Join(backupDir, $"{hash}.pak");
                        Directory.CreateDirectory(backupDir);
                        File.Copy(Archive.GetPath(), backupPath, true);
                        Console.WriteLine("Created backup: " + backupPath);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Could not create backup: {e.Message}\n{e.StackTrace}");
                    }
                }

                // Save archive
                Archive.Save(path, true);
                IsUpdated = false;

                ModalRenderer.CloseLoadingModal();

                if (launchGame)
                {
                    Archive.TryRunLevel();
                }
            })
            .ContinueWith(t =>
            {
                if (t.IsFaulted && t.Exception != null)
                {
                    foreach (var ex in t.Exception.InnerExceptions)
                    {
                        CrashHandler.Log($"Error saving archive: {ex.Message}\n{ex.StackTrace}");
                    }
                    string logPath = CrashHandler.WriteLogsToFile();
                    ModalRenderer.ShowMessageModal("Error", $"An error occured while saving the archive. Log saved to:\n\n{logPath}");
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
        }

        /// <summary>
        /// Create a copy of a file in the archive and set the focus to it
        /// </summary>
        private void DuplicateFile(IgArchiveFile file)
        {            
            IgArchiveFile clone = Archive.CloneFile(file);
            
            _treeView.AddFile(clone);

            SetFileUpdated(clone, isNewFile: true);
        }

        /// <summary>
        /// Open the rename modal for a file
        /// </summary>
        private void RenameFile(IgArchiveFile file)
        {
            if (FileManager.IsFileUpdated(file))
            {
                ModalRenderer.ShowMessageModal("Invalid operation", "Cannot rename this file because it currently has pending changes.");
                return;
            }

            ModalRenderer.ShowRenameModal(file.GetName(), (newName) =>
            {
                string originalPath = file.GetPath();
                file.Rename(newName);
                _treeView.RefreshFile(file);

                // Refresh the IGZ renderer
                FileManager.GetRenderer(file)?.ReloadFile();

                SetFileUpdated(file, originalPath: originalPath);
            });
        }

        /// <summary>
        /// Remove a file from the archive and the tree
        /// </summary>
        public void RemoveFile(IgArchiveFile file)
        {
            FileManager.Remove(file, true);
            Archive.RemoveFile(file);
            _treeView.RemoveFile(file);
            _includeInPackageFile.Remove(file);
            IsUpdated = true;
            FocusNode(null);
        }

        /// <summary>
        /// Extract and save the content of a file to disk
        /// </summary>
        private void ExtractFile(IgArchiveFile file)
        {
            string? filePath = FileExplorer.SaveFile("", FileExplorer.EXT_ALL, file.GetName());

            if (filePath != null)
            {
                file.Save(filePath);
            }
        }

        /// <summary>
        /// Revert the changes made to a file and refresh the associated views
        /// </summary>
        private void DiscardChanges(IgArchiveFile file)
        {
            // Remove newly created files
            if (FileManager.IsNewFile(file))
            {
                Archive.RemoveFile(file);
                _treeView.RemoveFile(file);
                FocusNode(null);
                return;
            }

            // Refresh the file path and tree for renamed files
            string? originalPath = FileManager.GetOriginalPath(file);
            if (originalPath != null)
            {
                file.SetPath(originalPath);
                _treeView.RefreshFile(file);
            }

            // Refresh the IGZ renderer
            FileManager.DiscardChanges(file);

            // Re-focus the file
            if (_selectedFile == file)
            {
                FocusFile(file, true);
            }
        }

        /// <summary>
        /// Display a modal to create a new empty IGZ file
        /// </summary>
        /// <param name="baseName">Base file name</param>
        /// <param name="basePath">Base file path</param>
        public void CreateFile(string baseName, string basePath = "")
        {
            ModalRenderer.ShowRenameModal(baseName, (fileName) => 
            {
                if (!fileName.Contains("."))
                {
                    fileName += ".igz";
                }
                else if (!fileName.EndsWith(".igz") && !fileName.EndsWith(".lng"))
                {
                    ModalRenderer.ShowMessageModal("Error", "Invalid extension: ." + fileName.Split('.')[1]);
                    return;
                }
                
                string path = basePath + fileName;

                IgzFile igz = new IgzFile(path, [ new igObject() { ObjectName = "DummyObject" } ]);
                IgArchiveFile file = new IgArchiveFile(path);
                file.SetData(igz.Save());

                AddFile(file, focusFile: true);
                _treeView.SetSelectedNode(_treeView.FindNode(file));
            });
        }

        /// <summary>
        /// Render the right-click context menu for a tree node
        /// </summary>
        public void RenderNodePopup(IgArchiveFile file)
        {
            bool includeInPkg = _includeInPackageFile.Contains(file);

            if (!file.GetPath().StartsWith("packages/") && ImGui.Checkbox("Include in package file", ref includeInPkg))
            {
                IsUpdated = true;

                if (includeInPkg) _includeInPackageFile.Add(file);
                else _includeInPackageFile.Remove(file);
            }
            if (FileManager.IsFileUpdated(file))
            {
                if (ImGui.Selectable("Discard changes")) DiscardChanges(file);
                ImGui.Separator();
            }
            if (ImGui.Selectable("Rename"))    RenameFile(file);
            if (ImGui.Selectable("Duplicate")) DuplicateFile(file);
            if (ImGui.Selectable("Extract"))   ExtractFile(file);
            if (ImGui.Selectable("Delete"))    RemoveFile(file);
        }

        /// <summary>
        /// Clone an object from an external archive, including all its dependencies
        /// </summary>
        public T Clone<T>(T sourceObject, IgArchive sourceArchive, IgzFile sourceIgz, IgzFile destIgz, Dictionary<igObject, igObject>? clones = null, bool excludeMapFiles = false) where T : igObject
        {
            T clone = IgzFile.Clone(sourceObject, sourceArchive, Archive, sourceIgz, destIgz, out List<IgArchiveFile> newFiles, clones);

            foreach (IgArchiveFile file in newFiles)
            {
                bool addToPkg = !file.GetPath().StartsWith("maps/") || file.GetPath().StartsWith("maps/Custom/");
                if (excludeMapFiles && file.GetPath().StartsWith("maps/")) continue;
                AddFile(file, addToPkg);
            }

            return clone;
        }

        /// <summary>
        /// Add a file and all its dependencies to the archive
        /// </summary>
        public void AddFileWithDependencies(IgArchive sourceArchive, IgArchiveFile file, bool focus = false)
        {
            bool addToPkg = !file.GetPath().StartsWith("maps/") || file.GetPath().StartsWith("maps/Custom/");
            
            AddFile(file, addToPkg, focus);

            if (!file.IsIGZ())
            {
                return;
            }

            HashSet<string> dependencies = file.ToIgzFile().GetDependencies().ToHashSet();

            List<IgArchiveFile> added = IgArchiveExtensions.FindDependencies(sourceArchive, Archive, dependencies);

            for (int i = 0; i < added.Count; i++)
            {
                IgArchiveFile newFile = added[i];
                addToPkg = !newFile.GetPath().StartsWith("maps/") || newFile.GetPath().StartsWith("maps/Custom/");
                AddFile(newFile, addToPkg);
            }
        }
    }
}