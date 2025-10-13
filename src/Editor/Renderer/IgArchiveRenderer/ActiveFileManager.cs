using Alchemy;
using Havok;

namespace NST
{
    /// <summary>
    /// Holds information about an updated igEntity with collision data
    /// </summary>
    public class CollisionUpdateInfos
    {
        public igEntity entity; // Updated entity
        public string namespaceName; // File namespace

        public int shapeIndex = -1; // Shape index in the current archive's StaticCollision.igz
        public hknpShapeInstance? shapeInstance = null; // Full shape instance
        
        /// <summary>
        /// Create a reference to the updated entity
        /// </summary>
        public HashedReference reference
        {
            get => entity.ToNamedReference(namespaceName).ToEXID();
        }
    }

    /// <summary>
    /// Holds information about an igArchive file that has been updated or is currently active
    /// </summary>
    public class FileUpdateInfos
    {
        public IgArchiveFile file; // Updated file
        public FileRenderer? renderer = null; // Parent renderer
        public IgzFile? igz = null; // IGZ instance

        public List<object> updatedObjects = []; // All updated objects
        public Dictionary<igEntity, CollisionUpdateInfos> updatedCollisions = []; // Updated entities

        public bool updated = false; // Whether the file has been updated
        public bool keepActive = false; // Whether to keep the file active when it's not updated
        public bool removeOnDiscard = false; // Whether to remove the file from the archive on "Discard"
        public string? originalPath = null; // The original path of the file after a rename

        public bool IsWindow() => renderer != null && renderer.IsOpenAsWindow;

        public FileUpdateInfos(IgArchiveFile file, FileRenderer? renderer)
        {
            this.file = file;
            this.renderer = renderer;
            if (renderer is IgzRenderer igzRenderer) this.igz = igzRenderer.Igz;
        }

        public FileUpdateInfos(IgArchiveFile file, IgzFile? igz = null, bool keepActive = false)
        {
            this.file = file;
            this.igz = igz;
            this.keepActive = keepActive;
        }
        
        /// <summary>
        /// Apply the changes made to the file.
        /// If the file is an IGZ file, its content will be saved.
        /// </summary>
        public void Apply()
        {
            updated = false;
            removeOnDiscard = false;

            updatedObjects.Clear();
            updatedCollisions.Clear();

            if (renderer != null)
            {
                renderer.TreeView.RemoveUnreferencedNodes();
                renderer.TreeView.ClearUpdatedNodes();

                // Apply changes to IGZ file
                file.SetData(renderer.SaveFile());
            }
            else 
            if (igz != null)
            {
                // Save IGZ file
                file.SetData(igz.Save());
            }
        }

        /// <summary>
        /// Revert the changes made to the file.
        /// If the file is an IGZ file, its renderer will be reloaded.
        /// </summary>
        public void Discard()
        {
            updated = false;

            if (renderer != null)
            {
                // Reload IGZ renderer
                renderer.ReloadFile();
            }
        }

        public void RenderWindow()
        {
            if (renderer != null && renderer.IsOpenAsWindow)
            {
                renderer.Render();
            }
        }
    }

    /// <summary>
    /// Manages the list of active and/or updated files.
    /// Allow for synchronization between the igArchiveRenderer and the Level Editor
    /// </summary>
    public class ActiveFileManager
    {
        /// <summary>
        /// List of active and/or updated files
        /// </summary>
        private Dictionary<IgArchiveFile, FileUpdateInfos> _files = [];

        /// <summary>
        /// Check if a file has been updated
        /// </summary>
        public bool IsFileUpdated(IgArchiveFile file) => _files.ContainsKey(file) && _files[file].updated;

        /// <summary>
        /// Check if a file is a new file
        /// </summary>
        public bool IsNewFile(IgArchiveFile file) => _files.ContainsKey(file) && _files[file].removeOnDiscard;

        /// <summary>
        /// Get the original path of a file (if it has been renamed)
        /// </summary>
        public string? GetOriginalPath(IgArchiveFile file) => _files.ContainsKey(file) ? _files[file].originalPath : null;

        /// <summary>
        /// Get the IGZ instance associated to a file, if it exists
        /// </summary>
        public IgzFile? GetIgz(IgArchiveFile file) => _files.ContainsKey(file) ? _files[file].igz ?? (_files[file].renderer as IgzRenderer)?.Igz : null;

        /// <summary>
        /// Get the list of updated files
        /// </summary>        
        public Dictionary<IgArchiveFile, FileUpdateInfos> GetUpdatedFiles() => _files.Where(f => f.Value.updated).ToDictionary();

        /// <summary>
        /// Keep a file active even if it hasn't been updated
        /// </summary>
        public void KeepActive(IgArchiveFile file) => _files[file].keepActive = true;

        /// <summary>
        /// Check if a renderer is associated to any file
        /// </summary>
        public bool HasRenderer(FileRenderer renderer) => _files.Values.Any(f => f.renderer == renderer);

        public FileUpdateInfos? GetInfos(IgArchiveFile file) => _files.ContainsKey(file) ? _files[file] : null;

        /// <summary>
        /// Add a file to the list of active files.
        /// </summary>
        /// <param name="file">The file to add</param>
        /// <param name="renderer">For IGZ files, the renderer associated to the file</param>
        public void Add(IgArchiveFile file, FileRenderer? renderer = null)
        {
            if (_files.ContainsKey(file) && renderer != null)
            {
                _files[file].renderer = renderer;
                return;
            }
            
            _files.Add(file, new FileUpdateInfos(file, renderer));
        }

        /// <summary>
        /// (Level-Editor) Add an IGZ file without a renderer to the list of active files
        /// </summary>
        public void Add(IgArchiveFile file, IgzFile igz, bool keepActive = false)
        {
            if (_files.ContainsKey(file))
            {
                _files[file].igz = igz;
                _files[file].keepActive |= keepActive;
                return;
            }
            _files.Add(file, new FileUpdateInfos(file, igz, keepActive));
        }


        /// <summary>
        /// Mark a file as updated.
        /// Add the file to the list of active files if it doesn't exist.
        /// </summary>
        /// <param name="file">The file to add</param>
        /// <param name="removeOnDiscard">Whether to remove the file from the archive on "Discard"</param>
        /// <param name="originalPath">The original path of the file for rename operations</param>
        public FileUpdateInfos SetUpdated(IgArchiveFile file, bool removeOnDiscard = false, string? originalPath = null)
        {
            if (!_files.TryGetValue(file, out FileUpdateInfos? infos))
            {
                Add(file);
                infos = _files[file];
            }

            infos.updated = true;

            if (removeOnDiscard) infos.removeOnDiscard = removeOnDiscard;
            if (originalPath != null) infos.originalPath = originalPath;

            return infos;
        }

        /// <summary>
        /// Get the renderer associated to a file if it exists
        /// </summary>
        public FileRenderer? GetRenderer(IgArchiveFile file)
        {
            if (_files.TryGetValue(file, out FileUpdateInfos? infos))
            {
                return infos.renderer;
            }

            return null;
        }

        /// <summary>
        /// (Level-Editor) Get the IGZ renderer associated to a reference, or create it if it doesn't exist
        /// </summary>
        public IgzRenderer? GetOrCreateRenderer(NamedReference reference, IgArchiveRenderer archiveRenderer)
        {
            string namespaceName = reference.namespaceName.ToLowerInvariant();
            IgArchiveFile? file = _files.Keys.FirstOrDefault(f => f.GetName(false).ToLowerInvariant() == namespaceName);

            if (file == null) 
            {
                Console.WriteLine($"Could not find file {namespaceName} in active files");
                return null;
            }

            IgzRenderer renderer = GetOrCreateRenderer(file, archiveRenderer);
            renderer.TreeView.SelectNode(reference, false);
            
            return renderer;
        }
        /// <summary>
        /// (Level-Editor) Get the IGZ renderer associated to a file, or create it if it doesn't exist
        /// </summary>
        public IgzRenderer GetOrCreateRenderer(IgArchiveFile file, IgArchiveRenderer archiveRenderer)
        {
            if (!_files.TryGetValue(file, out FileUpdateInfos? infos))
            {
                infos = new FileUpdateInfos(file);
                _files[file] = infos;
            }
            if (infos.renderer != null)
            {
                // Console.WriteLine($"[GetOrCreateRenderer] Reusing renderer for {file.GetName(false)}" + "#" + infos.igz?.uid);
                return (IgzRenderer)infos.renderer;
            }

            // Console.WriteLine($"[GetOrCreateRenderer] Creating renderer for {file.GetName(false)}, igz ? {infos.igz != null}" + "#" + infos.igz?.uid);

            IgzRenderer renderer = new IgzRenderer(infos.igz ?? file.ToIgzFile(), file, archiveRenderer);
            infos.renderer = renderer;
            infos.igz = renderer.Igz;

            return renderer;
        }
        
        /// <summary>
        /// Apply the changes made to a file.
        /// </summary>
        /// <param name="removeFromActive">Whether to remove the file from the active list</param>
        // public void ApplyChanges(IgArchiveFile file, bool removeFromActive = false)
        public void ApplyChanges(FileUpdateInfos infos, bool removeFromActive = false)
        {
            // if (!_files.TryGetValue(file, out FileUpdateInfos? infos)) return;

            infos.Apply();

            if (removeFromActive && !infos.keepActive && !infos.IsWindow())
            {
                _files.Remove(infos.file);
            }
        }

        /// <summary>
        /// Revert the changes made to a file
        /// </summary>
        public void DiscardChanges(IgArchiveFile file)
        {
            if (!_files.TryGetValue(file, out FileUpdateInfos? infos)) return;

            infos.Discard();

            if (!infos.keepActive && !infos.IsWindow())
            {
                _files.Remove(file);
            }
        }

        /// <summary>
        /// Try to remove a file from the list of active files
        /// </summary>
        /// <param name="file">The file to remove</param>
        /// <param name="force">Whether to check if the file can be removed</param>
        public void Remove(IgArchiveFile file, bool force = false)
        {
            if (!_files.TryGetValue(file, out FileUpdateInfos? infos)) return;

            if (!force)
            {
                if (infos.updated) return;
                if (infos.keepActive) return;
                if (infos.IsWindow()) return;
            }

            _files.Remove(file);
        }

        /// <summary>
        /// Render IGZ files that were popped out as external windows
        /// </summary>
        public void RenderWindows()
        {
            foreach (FileUpdateInfos file in _files.Values.ToList())
            {
                file.RenderWindow();
            }
        }

        public override string ToString()
        {
            List<FileUpdateInfos> infos = _files.Values.ToList();
            return $"({ImGuiUtils.id}) Active files: {infos.Count}, Updated files: {infos.Count(f => f.updated)}, Renderers: {infos.Count(f => f.renderer != null)}, Windows: {infos.Count(f => f.IsWindow())}";
        }
    }
}