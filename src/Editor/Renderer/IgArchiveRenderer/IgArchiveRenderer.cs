using Alchemy;
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
        private Dictionary<HashedReference, int> _collisionData = [];
        private HashSet<IgArchiveFile> _includeInPackageFile = [];

        private uint _uuid;
        private bool _isOpen = true;
        private bool _isUpdated = false;
        private bool _showAudioPlayer = false; // Used for .snd files
        private bool _hasBackup = false;
        private bool _compressOnSave = true;
        private bool _isLevelArchive = false;

        public string GetWindowName() => (string.IsNullOrEmpty(Archive.GetName()) ? "New Archive" : Archive.GetName()) + "###" + _uuid;
        public int FindCollisionShapeIndex(HashedReference reference) => _collisionData.ContainsKey(reference) ? _collisionData[reference] : -1;
        public int FindCollisionShapeIndex(NamedReference reference) => FindCollisionShapeIndex(reference.ToEXID());
        public bool IncludeInPackageFile(IgArchiveFile file) => _includeInPackageFile.Contains(file);

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
            
            _collisionData = StaticCollisionsUtils.GetCollisionData(Archive);
            _compressOnSave = LocalStorage.Get("compress_on_save_" + Archive.GetPath(), true);
            _hasBackup = File.Exists(Archive.GetPath() + ".backup");
            _includeInPackageFile.Clear();
            _selectedFile = null;
            _showAudioPlayer = false;

            IgArchiveFile? packageFile = Archive.FindPackageFile();

            if (packageFile == null) return;
            
            _isLevelArchive = true;

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
        public void AddFile(IgArchiveFile file, bool addToPackageFile = true)
        {
            Archive.AddFile(file);
            _treeView.AddFile(file);

            if (addToPackageFile) _includeInPackageFile.Add(file);
        }

        /// <summary>
        /// Renders the window and its contents
        /// </summary>
        public void Render()
        {
            if (!_isOpen)
            {
                TryCloseArchive();
                return;
            }

            Vector2 displaySize = ImGui.GetIO().DisplaySize;
            ImGui.SetNextWindowSize(displaySize * new Vector2(1, 0.5f), ImGuiCond.FirstUseEver);
            ImGui.SetNextWindowPos(Vector2.Zero, ImGuiCond.FirstUseEver);

            ImGuiWindowFlags flags = ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse | ImGuiWindowFlags.MenuBar;

            if (_isUpdated) flags |= ImGuiWindowFlags.UnsavedDocument;

            if (ImGui.Begin(GetWindowName(), ref _isOpen, flags))
            {
                float columnWidth = ImGui.GetContentRegionAvail().X * 0.3f;

                RenderMenuBar();
                
                if (_isLevelArchive && ImGui.Button("Open Level Editor"))
                {
                    App.OpenLevelExplorer(this);
                }

                if (ImGui.BeginTable("TreeAndInfo", 2, ImGuiTableFlags.Resizable | ImGuiTableFlags.RowBg))
                {
                    ImGui.TableSetupColumn("igArchiveTree", ImGuiTableColumnFlags.WidthFixed, columnWidth);
                    ImGui.TableSetupColumn("igzRenderer", ImGuiTableColumnFlags.WidthStretch);
                    ImGui.TableNextRow();
                    ImGui.TableNextColumn();
                    
                    // ImGui.Text(FileManager.ToString());

                    // Render tree view
                    _treeView.Render();

                    // Render current file
                    RenderFile();

                    ImGui.EndTable();
                }

                // Shortcuts
                if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.S)) TrySaveArchive(); // Save
                if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.ModShift | ImGuiKey.S)) SaveArchive(true); // Save as
                if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.E)) App.OpenLevelExplorer(this); // Level Explorer
                if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.ModShift | ImGuiKey.R)) RestoreBackup(); // Restore backup
            }

            // Render undocked IGZs
            FileManager.RenderWindows();
            
            ImGui.End();
        }

        private void RenderMenuBar()
        {
            if (ImGui.BeginMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGui.MenuItem("Save", "Ctrl+S")) TrySaveArchive();
                    if (ImGui.MenuItem("Save as...", "Ctrl+Shift+S")) SaveArchive(true);
                    if (ImGui.MenuItem("Compress on save", null, _compressOnSave))
                    { 
                        _compressOnSave = !_compressOnSave;
                        LocalStorage.Set("compress_on_save_" + Archive.GetPath(), _compressOnSave);
                    }
                    ImGui.Separator();
                    if (ImGui.MenuItem("Close")) _isOpen = false;

                    ImGui.EndMenu();
                }

                if (ImGui.BeginMenu("Backup"))
                {
                    if (!_hasBackup)
                    {
                        ImGui.MenuItem("No backup found", null, false, false);
                        if (ImGui.MenuItem("Create backup")) CreateBackup();
                    }
                    else
                    {
                        ImGui.MenuItem("Backup found!", null, false, false);
                        if (ImGui.MenuItem("Restore backup", "Ctrl+Shift+R")) RestoreBackup();
                        if (ImGui.MenuItem("Delete backup")) DeleteBackup();
                    }
                    ImGui.EndMenu();
                }

                ImGui.EndMenuBar();
            }
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

        private void RestoreBackup()
        {
            if (!_hasBackup) return;
            
            File.Copy(Archive.GetPath() + ".backup", Archive.GetPath(), true);

            Archive = IgArchive.Open(Archive.GetPath());

            Setup();

            _isUpdated = true;
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
                AudioPlayerInstance.Render();
            }
            // unsupported files
            else
            {
                ImGui.TextColored(new Vector4(1, 0.7f, 0, 1), $"    [ No preview available for {extension} files ]");
            }
        }

        /// <summary>
        /// Mark the archive and the file as updated
        /// </summary>
        /// <param name="file">The file that has been updated</param>
        /// <param name="focusFile">Whether to set the focus to the updated file.</param>
        /// <param name="isNewFile">Whether the updated file is a newly created file or an existing file</param>
        /// <param name="originalName">The original name of the file for rename operations</param>
        public FileUpdateInfos SetFileUpdated(IgArchiveFile file, bool focusFile = true, bool isNewFile = false, string? originalPath = null)
        {
            FileUpdateInfos infos = FileManager.SetUpdated(file, isNewFile, originalPath);
            
            if (focusFile)
            {
                IgArchiveTreeNode? node = _treeView.FindNode(file);
                if (node != null)
                {
                    FocusNode(node);
                }
            }

            _isUpdated = true;

            return infos;
        }

        /// <summary>
        /// Marks an object as updated. Also marks the archive and file as updated
        /// </summary>
        /// <param name="file">The parent file</param>
        /// <param name="obj">The object that has been updated</param>
        public FileUpdateInfos SetObjectUpdated(IgArchiveFile file, object? obj)
        {
            FileUpdateInfos infos = SetFileUpdated(file, false);

            if (obj != null) {
                infos.updatedObjects.Add(obj);
            }
            
            return infos;
        }

        /// <summary>
        /// Marks an igEntity as updated with its collision data. Also marks the archive and file as updated
        /// </summary>
        /// <param name="file">The parent file</param>
        /// <param name="obj">The entity that has been updated</param>
        /// <param name="shapeIndex">The Havok shape index in the archive's StaticCollision.hkx</param>
        /// <param name="shapeInstance">The Havok shape instance (not required if shapeIndex is set)</param>
        public void SetEntityUpdated(IgArchiveFile file, igEntity entity, int? shapeIndex = null, Havok.hknpShapeInstance? shapeInstance = null)
        {
            FileUpdateInfos infos = SetObjectUpdated(file, entity);

            if (shapeIndex == -1 || infos.updatedCollisions.Keys.Contains(entity)) return;
            if (shapeIndex == null && shapeInstance == null) return;
            
            string namespaceName = file.GetName(false);
            NamedReference reference = entity.ToNamedReference(namespaceName);

            var updateInfos = new CollisionUpdateInfos() { 
                entity = entity, 
                shapeIndex = shapeIndex ?? FindCollisionShapeIndex(reference.ToEXID()), 
                shapeInstance = shapeInstance,
                namespaceName = namespaceName
            };
            infos.updatedCollisions.Add(updateInfos.entity, updateInfos);
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

            OpenFile(node.File, reference, lastRenderer);
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

            if (renderer == null)
            {
                // Create a new renderer
                if (infos?.igz == null)
                {
                    renderer = FileRenderer.Create(file, this);
                    FileManager.Add(file, renderer);
                }
                // Create a new renderer using an open igz file
                else
                {
                    renderer = new IgzRenderer(infos.igz, file, this);
                    infos.renderer = renderer;
                }
            }
            // Focus the renderer
            else if (renderer.IsOpenAsWindow)
            {
                ImGui.SetWindowFocus(renderer.GetWindowName());
            }

            if (reference != null && renderer is IgzRenderer igzRenderer)
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

        public void TryCloseArchive()
        {
            if (_isUpdated)
            {
                ModalRenderer.ShowWarningModal("Are you sure you want to close the archive without saving?", () => { _isUpdated = false; _isOpen = false; });
                _isOpen = true;
            }
            else
            {
                App.CloseArchive(this);
            }
        }

        /// <summary>
        /// Try to save the current archive to disk.
        /// Will show a confirmation modal if it's a game archive.
        /// </summary>
        public void TrySaveArchive()
        {
            if (!_isUpdated) return;

            if (LocalStorage.GamePath != null && Archive.GetPath().StartsWith(LocalStorage.GamePath) && !_hasBackup) // Check if overwriting a game file
            {
                ModalRenderer.ShowConfirmationModal(
                    "Warning: you're about to overwrite a game file with no backup!\n\nThe recommended approach is to copy the files you want to edit to a new archive (mod), then use the mod manager to apply them.", 
                    () =>  SaveArchive(true), // Save as...
                    () =>  SaveArchive(false) // Overwrite
                );
            }
            else
            {
                SaveArchive();
            }
        }

        /// <summary>
        /// Save the current archive to disk
        /// </summary>
        /// <param name="saveAs">If true will open the file saving explorer, otherwise will overwrite the current file</param>
        private void SaveArchive(bool saveAs = false)
        {
            string? path = Archive.GetPath();

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

            if (saveAs || string.IsNullOrEmpty(path))
            {
                path = FileExplorer.SaveFile("", FileExplorer.EXT_ARCHIVES, Archive.GetName());
                if (path == null) return;
                LocalStorage.AddRecentFile(path);

                if (!_compressOnSave)
                {
                    LocalStorage.Set("compress_on_save_" + path, _compressOnSave);
                }
            }

            List<CollisionUpdateInfos> updatedCollisions = [];

            // Loop through all updated files
            foreach ((IgArchiveFile archiveFile, FileUpdateInfos infos) in FileManager.GetUpdatedFiles())
            {
                // Add updated collisions
                updatedCollisions.AddRange(infos.updatedCollisions.Values);

                // Save file
                FileManager.ApplyChanges(infos, _selectedFile != archiveFile);
            }

            // Rebuild collisions if needed
            if (updatedCollisions.Count > 0)
            {
                StaticCollisionsUtils.RebuildCollisions(Archive, updatedCollisions);
            }

            // Rebuild package file if needed
            List<IgArchiveFile> includedFiles = Archive.GetFiles().Where(e => _includeInPackageFile.Contains(e)).ToList();
            Archive.RebuildPackageFile(includedFiles);

            if (_compressOnSave)
            {
                Archive.CompressAll();
            }
            else
            {
                Archive.UncompressAll();
            }

            // Save archive
            Archive.Save(path, true);
            _isUpdated = false;
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
        /// Open the delete modal for a file
        /// </summary>
        private void DeleteFile(IgArchiveFile file)
        {
            ModalRenderer.ShowDeleteModal("Are you sure you want to delete " + file.GetName() + "?", () =>
            {
                FileManager.Remove(file, true);
                Archive.RemoveFile(file);
                _treeView.RemoveFile(file);
                _includeInPackageFile.Remove(file);
                _isUpdated = true;
                FocusNode(null);
            });
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
        /// Render the right-click context menu for a tree node
        /// </summary>
        public void RenderNodePopup(IgArchiveFile file)
        {
            bool includeInPkg = _includeInPackageFile.Contains(file);

            if (!file.GetPath().StartsWith("packages/") && ImGui.Checkbox("Include in package file", ref includeInPkg))
            {
                _isUpdated = true;

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
            if (ImGui.Selectable("Delete"))    DeleteFile(file);
        }

        public T Clone<T>(T sourceObject, IgArchive sourceArchive, IgzFile sourceIgz, IgzFile destIgz, Dictionary<igObject, igObject>? clones = null) where T : igObject
        {
            List<IgArchiveFile> prevFiles = Archive.GetFiles().ToList();

            T clone = IgzFile.Clone(sourceObject, sourceArchive, Archive, sourceIgz, destIgz, clones);

            foreach (IgArchiveFile file in Archive.GetFiles().ToList().Except(prevFiles))
            {
                if (!file.GetPath().StartsWith("maps/") || file.GetPath().StartsWith("maps/Custom/"))
                {
                    _includeInPackageFile.Add(file);
                }

                _treeView.AddFile(file);
            }

            return clone;
        }
    }
}