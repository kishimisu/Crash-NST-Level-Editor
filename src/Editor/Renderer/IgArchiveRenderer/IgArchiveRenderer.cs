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
        public IgArchive Archive { get; }
        public ActiveFileManager FileManager { get; } = new ActiveFileManager();

        private IgArchiveTreeView _treeView;
        private IgArchiveFile? _selectedFile = null;
        private Dictionary<HashedReference, int> _collisionData = [];

        private bool _isOpen = true;
        private bool _isUpdated = false;
        private bool _showAudioPlayer = false; // Used for .snd files

        public string GetWindowName() => (string.IsNullOrEmpty(Archive.GetName()) ? "New Archive" : Archive.GetName()) + "##" + GetHashCode();
        public int FindCollisionShapeIndex(HashedReference reference) => _collisionData.ContainsKey(reference) ? _collisionData[reference] : -1;

        public IgArchiveRenderer(string archivePath)
        {
            Archive = IgArchive.Open(archivePath);
            _treeView = new IgArchiveTreeView(this);
            _collisionData = StaticCollisionsUtils.GetCollisionData(Archive);
        }
        public IgArchiveRenderer(IgArchive archive)
        {
            Archive = archive;
            _treeView = new IgArchiveTreeView(this);
            _collisionData = StaticCollisionsUtils.GetCollisionData(Archive);
        }

        /// <summary>
        /// Renders the window and its contents
        /// </summary>
        public void Render()
        {
            Vector2 displaySize = ImGui.GetIO().DisplaySize;
            ImGui.SetNextWindowSize(displaySize * new Vector2(1, 0.5f), ImGuiCond.FirstUseEver);
            ImGui.SetNextWindowPos(Vector2.Zero, ImGuiCond.FirstUseEver);

            if (!_isOpen)
            {
                App.CloseArchive(this);
                return;
            }

            ImGuiWindowFlags flags = ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse;

            if (_isUpdated) flags |= ImGuiWindowFlags.UnsavedDocument;

            if (ImGui.Begin(GetWindowName(), ref _isOpen, flags))
            {
                float columnWidth = ImGui.GetContentRegionAvail().X * 0.3f;
                
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
                if (ImGui.Shortcut(ImGuiKey.W)) _isOpen = false; // Close
                if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.S)) TrySaveArchive(); // Save
                if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.ModShift | ImGuiKey.S)) SaveArchive(true); // Save as
            }

            // Render undocked IGZs
            FileManager.RenderWindows();
            
            ImGui.End();
        }

        /// <summary>
        /// Renders the currently selected file
        /// </summary>
        private void RenderFile()
        {
            if (_selectedFile == null) return;

            FileRenderer? renderer = FileManager.GetRenderer(_selectedFile);
            bool isWindow = false;

            if (renderer != null)
            {
                if (!renderer.IsOpenAsWindow)
                {
                    // Show the current IgzRenderer on the right
                    ImGui.TableNextColumn();
                    renderer.Render();
                    return;
                }

                isWindow = true;
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
            // files that are opened as windows
            else if (isWindow)
            {
                ImGui.TextColored(new Vector4(1, 0.7f, 0, 1), "    [ Open in another window ]");
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

            if (infos.updatedCollisions.Keys.Contains(entity)) return;
            
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

            FocusNode(node, reference, lastRenderer);

            return true;
        }
        
        /// <summary>
        /// Focus a file in the tree view and open its content
        /// </summary>
        public void FocusFile(IgArchiveFile file)
        {
            FocusNode(_treeView.FindNode(file));
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

            _treeView.SetSelectedNode(node, true);

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
            if (_selectedFile != null)
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

            FileRenderer? renderer = FileManager.GetRenderer(file);

            // Try to focus the previously opened renderer
            if (renderer != null)
            {
                if (renderer.IsOpenAsWindow)
                {
                    ImGui.SetWindowFocus(renderer.GetWindowName());
                }
                else
                {
                    _selectedFile = renderer.ArchiveFile; // todo: check if can use 'file' instead
                }
            }
            // Create a new renderer
            else
            {
                renderer = FileRenderer.Create(file, this);
                
                FileManager.Add(file, renderer);
            }

            // Focus the referenced object
            if (reference != null && renderer is IgzRenderer igzRenderer)
            {
                igzRenderer.TreeView.SelectNode(reference);
                igzRenderer.LastRenderer = lastRenderer;
            }
            else if (renderer.TreeView.SelectedNode != null)
            {
                renderer.TreeView.ExpandParents(renderer.TreeView.SelectedNode);
            }
        }

        /// <summary>
        /// Try to save the current archive to disk.
        /// Will show a confirmation modal if it's a game archive.
        /// </summary>
        public void TrySaveArchive()
        {
            if (!_isUpdated) return;

            if (LocalStorage.GamePath != null && Archive.GetPath().StartsWith(LocalStorage.GamePath)) // Check if overwriting a game file
            {
                ModalRenderer.ShowConfirmationModal(
                    "Warning: you're about to overwrite a game file!\n\nThe recommended approach is to copy the files you want to edit to a new archive (mod), then use the mod manager to apply them.", 
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

            if (saveAs || string.IsNullOrEmpty(path))
            {
                path = FileExplorer.SaveFile("", FileExplorer.EXT_ARCHIVES, Archive.GetName());
                if (path == null) return;
                LocalStorage.AddRecentFile(path);
            }

            List<CollisionUpdateInfos> updatedCollisions = [];

            // Loop through all updated files
            foreach ((IgArchiveFile archiveFile, FileUpdateInfos infos) in FileManager.GetUpdatedFiles())
            {
                if (!infos.updated) continue;

                // Add updated collisions
                updatedCollisions.AddRange(infos.updatedCollisions.Values);

                // Save file
                FileManager.ApplyChanges(archiveFile, _selectedFile != archiveFile);
            }

            // Rebuild collisions if needed
            if (updatedCollisions.Count > 0)
            {
                StaticCollisionsUtils.RebuildCollisions(this, updatedCollisions);
            }

            // Rebuild package file if needed
            RebuildPackageFile();

            // Save archive
            Archive.Save(path, true);
            _isUpdated = false;
        }

        /// <summary>
        /// Rebuild the archive's package file by adding new files
        /// </summary>
        private void RebuildPackageFile()
        {
            List<string> fileTypeOrder = [
                "script", "sound_sample", "sound_bank", "lang_file", "loose", "shader",
                "texture", "material_instances", "font", "vsc", "igx_file", 
                "havokrigidbody", "model", "asset_behavior", 
                "havokanimdb", "hkb_behavior", "hkc_character", 
                "behavior", "sky_model", "effect", "actorskin", 
                "sound_stream", "character_events", "graphdata_behavior", 
                "character_data", "gui_project",
                "navmesh", "igx_entities", "pkg"
            ];

            IgArchiveFile? packageFile = Archive.FindPackageFile();

            if (packageFile == null)
            {
                return;
            }

            IgzFile packageIgz = packageFile.ToIgzFile();

            var chunkInfo = packageIgz.FindObject<igStreamingChunkInfo>()!;
            bool needsRebuild = false;

            foreach (IgArchiveFile file in Archive.GetFiles())
            {
                if (file == packageFile) continue;

                string filePath = file.GetPath().ToLower();
                bool exists = chunkInfo._required._data.Any(x => x._name == filePath);

                if (!exists)
                {
                    chunkInfo._required._data.Add(new ChunkFileInfoMetaField
                    {
                        _name = filePath,
                        _type = "igx_entities" // TODO: Find file type dynamically
                    });

                    needsRebuild = true;

                    Console.WriteLine($"Added {file.GetName()} to package file.");
                }
            }

            if (needsRebuild) 
            {
                chunkInfo._required._data.Sort((a, b) => fileTypeOrder.IndexOf(a._type!) - fileTypeOrder.IndexOf(b._type!));
                packageFile.SetData(packageIgz.Save());
            }
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
            ModalRenderer.ShowDeleteModal(file.GetName(), () =>
            {
                FileManager.Remove(file, true);
                Archive.RemoveFile(file);
                _treeView.RemoveFile(file);
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
                FocusFile(file);
            }
        }

        /// <summary>
        /// Render the right-click context menu for a tree node
        /// </summary>
        public void RenderNodePopup(IgArchiveFile file)
        {
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
    }
}